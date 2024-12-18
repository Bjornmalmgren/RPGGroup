using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	private  float movementSpeed = 300.0f;

	[Export]
	public int health = 100;

	

	int frame;
	public override void _Ready()
	{
		Callable calls = new Callable(this, MethodName.Attacked);
		var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
		signalBuss.Connect(SignalBuss.SignalName.PlayerAttacked, calls, (uint)GodotObject.ConnectFlags.Persist);

	}
	private void Attacked(int damage)
	{

		if (damage < 0)
		{
            health += damage;
        }
		else {
            health -= damage;
        }
		
		var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
		signalBuss.EmitPlayerLostHealth(health);

	}
	public void Attack()
	{
		var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
		Vector2 direction = Input.GetVector("Left", "Right", "Up", "Down");

		if (direction == Vector2.Zero)
		{

			direction.X = Scale.Y;
		}

		Vector2 pos = Position;
		pos.X += direction.X * 60;
		pos.Y += direction.Y * 100;
		direction *= 10;
		signalBuss.EmitPlayerAttack(pos, direction);

	}
	public void Move()
	{
		Vector2 inputDir = Input.GetVector("Left", "Right", "Up", "Down");
		if (Input.IsActionJustPressed("Left", false))
		{

			Scale = new Vector2(1, -1);
			RotationDegrees = -180f;
		   
		}
		if (Input.IsActionJustPressed("Right", false))
		{
			Scale = new Vector2(1, 1);
			RotationDegrees = 0f;
			
		}
		
		Velocity = inputDir * movementSpeed;
	}
	public void OnDeath()
	{
		//GD.Print("dead");
		var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
		signalBuss.EmitPlayerDeath();
	}
	
	
	public override void _PhysicsProcess(double delta)
	{
		Move();
		MoveAndSlide();
		if(Input.IsActionJustPressed("Attack",false)&&frame>=120)
		{
			Attack();
			frame = 0;
		}
		if (health <=0)
		{
			OnDeath();
			
		}
		frame++;
	}
    public void reduceHealth(int amount)
    {
        if (amount < 0)
        {
            health += amount;
        }
        else
        {
            health -= amount;
        }
        //GD.Print(health);
    }

}
