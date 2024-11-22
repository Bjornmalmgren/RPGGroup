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
	bool moveToPlayer = false;
	Node2D player;
	int roamingRadius = 60;
	Vector2 startingPos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//setting values and getting the area
		startingPos = Position;
		health = 10;
		speed = 200;
		attackDamage = 1;
		detectionRadius = 30;
		area = (CollisionShape2D)this.GetChild(2).GetChild(0);
		area.Scale = new Vector2(detectionRadius, detectionRadius);
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//moves the enemy every 30 frames
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
		//when combat
	}
	void attack()
	{
		//later when making combat
	}
	void moveTowardsPlayer(Node2D body)
	{
		//makes the enemy walk towards the player
		moveToPlayer = true;
		player = body;
	}

	void walkAround()
	{
		//makes the enemy walk around again
        moveToPlayer = false;
		player = null;
    }

	void move()
	{
		//moves the enemy eithr randomly or towards the player
		if(moveToPlayer == false)
		{
            Random rand = new Random();
            int moveDirection = rand.Next(1, 5);
            switch (moveDirection)
            {
                //moves enemy up
                case 1:
                    ApplyForce(new Vector2(0, 2 * speed));
                    //Position = new Vector2(Position.X, Position.Y + speed);
                    break;
                //moves enemy down
                case 2:
                    ApplyForce(new Vector2(0, -2 * speed));
                    //Position = new Vector2(Position.X, Position.Y - speed);
                    break;
                //moves enemy to the right
                case 3:
                    ApplyForce(new Vector2(2 * speed, 0));
                    //Position = new Vector2(Position.X+ speed, Position.Y);
                    break;
                //moves enemy to the left
                case 4:
                    ApplyForce(new Vector2(-2 * speed, 0));
                    //Position = new Vector2(Position.X-speed, Position.Y);
                    break;
                default:
                    break;
            }

		}
		else
		{
			Vector2 direction = Position.DirectionTo(player.Position);
            ApplyForce(direction* speed);
            
		}
		
	}
}
