using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	private  float movementSpeed = 300.0f;

	[Export]
	public int health;

	private int attackCD;

	
	public void Move()
	{
		Vector2 inputDir = Input.GetVector("Left", "Right", "Up", "Down");
		if (Input.IsActionJustPressed("Left", false))
		{

			Scale = new Vector2(1, -1);
			RotationDegrees = -180f;
            GD.Print(Scale);
        }
		if (Input.IsActionJustPressed("Right", false))
		{
            Scale = new Vector2(1, 1);
            RotationDegrees = 0f;
            GD.Print(Scale);
        }
		//GD.Print(Scale);
		Velocity = inputDir * movementSpeed;
	}
	public void OnDeath()
	{

	}
	public void Attack()
	{

	}
	public override void _PhysicsProcess(double delta)
	{
		Move();
		MoveAndSlide();
		if(Input.IsActionJustPressed("Attack",false))
		{
			Attack();
		}
		if (health <=0)
		{
			OnDeath();
		}
	}
	
}
