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
	int roamingRadius = 600;
	Vector2 startingPos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//setting values and getting the area
		startingPos = Position;
		
		health = 12;
		speed = 200;
		attackDamage = 10;
		detectionRadius = 100;
		area = (CollisionShape2D)this.GetChild(2).GetChild(0);
		area.Scale = new Vector2(detectionRadius, detectionRadius);

        Callable calls = new Callable(this, MethodName.reduceHealth);
        var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
        signalBuss.Connect(SignalBuss.SignalName.EnemyHit, calls, (uint)GodotObject.ConnectFlags.Persist);
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
		if(health<=0)
		{
			
			QueueFree();
		}
	}
	void reduceHealth(int amount)
	{
		health -= amount;
		GD.Print(health);
	}
	void lostTarget(Node2D body)
	{
		GD.Print(body.Name);
	}
	void onDeath()
	{
		//when combat
	}
	void attack(Node2D body)
	{
		if(body.Name=="Player")
		{
            var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
			
			signalBuss.EmitPlayerAttacked(attackDamage);
        }
		//later when making combat
	}
	void moveTowardsPlayer(Node2D body)
	{
		GD.Print("found target");
		//makes the enemy walk towards the player
		moveToPlayer = true;
		player = body;
	}

	void walkAround(Node2D body)
	{
		//makes the enemy walk around again
		GD.Print("lost target");
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

		}else if (Position.X >= startingPos.X + roamingRadius || Position.X <= startingPos.X - roamingRadius || Position.Y >= startingPos.Y + roamingRadius || Position.Y <= startingPos.Y - roamingRadius)
		{
			Vector2 direction = Position.DirectionTo(startingPos);
			ApplyForce(direction * speed);
		}
		else
		{
			Vector2 direction = Position.DirectionTo(player.Position);
			ApplyForce(direction* speed);
			
		}
		
	}
}
