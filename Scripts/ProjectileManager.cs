using Godot;
using System;

public partial class ProjectileManager : Node
{
	//do this class after the projectile class has been created
	[Export]
	RigidBody2D projectileBase {  get; set; }
    Godot.Collections.Array<RigidBody2D> activeProjectiles = new Godot.Collections.Array<RigidBody2D>();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void spawnProjectile(Vector2 spawnPosition, Vector2 destination)
	{
		
        projectileBase.Position = spawnPosition;
       
        Projectile p = (Projectile)projectileBase;
		p.Position = spawnPosition;
		p.setDestination(destination);
		p.setStartingPos(spawnPosition);
		
		
		

    }
	void destroyProjectile()
	{

	}
}
