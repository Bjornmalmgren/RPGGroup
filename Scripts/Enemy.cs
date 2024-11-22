using Godot;
using System;

public partial class Enemy : RigidBody2D
{
	int health;
	int speed;
	int attackDamage;
	int detectionRadius;
	CollisionShape2D area;
	int frame;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		health = 10;
		speed = 200;
		attackDamage = 1;
		detectionRadius = 10;
		area = (CollisionShape2D)this.GetChild(2).GetChild(0);
		area.Scale = new Vector2(detectionRadius, detectionRadius);
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(frame >= 30) {
			frame = 0;
			move();
		}
		frame++;
	}

	void reduceHealth(int amount)
	{
		health -= amount;
	}
	void onDeath()
	{

	}
	void attack()
	{

	}
	void move()
	{
		Random rand = new Random();
		int moveDirection = rand.Next(1, 5);
		switch (moveDirection)
		{
			//moves enemy up
			case 1:
				ApplyForce(new Vector2(0, 2*speed));
				//Position = new Vector2(Position.X, Position.Y + speed);
				break;
			//moves enemy down
            case 2:
                ApplyForce(new Vector2(0, -2*speed));
                //Position = new Vector2(Position.X, Position.Y - speed);
                break;
			//moves enemy to the right
            case 3:
                ApplyForce(new Vector2(2*speed, 0));
                //Position = new Vector2(Position.X+ speed, Position.Y);
                break;
			//moves enemy to the left
            case 4:
                ApplyForce(new Vector2(-2*speed, 0));
                //Position = new Vector2(Position.X-speed, Position.Y);
                break;
            default:
				break;
		}
	}
}
