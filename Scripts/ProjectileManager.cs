using Godot;
using System;

public partial class ProjectileManager : Node
{
	//do this class after the projectile class has been created
	[Export]
	RigidBody2D projectileBase {  get; set; }
    Godot.Collections.Array<RigidBody2D> activeProjectiles = new Godot.Collections.Array<RigidBody2D>();
	int frame = 0;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		Callable calls = new Callable(this,MethodName.spawnProjectile);

        var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
        signalBuss.Connect(SignalBuss.SignalName.PlayerAttack, calls, (uint)GodotObject.ConnectFlags.Persist);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (frame >= 120)
		{
			frame = 0;
			Projectile p = (Projectile)GetChild(0);
	
			//p.LinearVelocity = new Vector2(0, 0);
			
			//p.Position = new Vector2(0, 0);

		}
		frame++;
	
	}

	
	public void spawnProjectile(Vector2 spawnPosition, Vector2 destination)
	{
		GD.Print("attack received");
		
        projectileBase.Position = spawnPosition;
       	
        Projectile p = (Projectile)projectileBase;
		
		p.setPosition(spawnPosition);
		p.setDestination(destination);
		p.setStartingPos(spawnPosition);
		

		
		

    }
	void destroyProjectile()
	{

	}
}
