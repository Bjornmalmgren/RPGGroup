using Godot;
using System;

public partial class Projectile : RigidBody2D
{
	Vector2 startingPosition;
    Vector2 destination;
    Vector2 direction;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        Position = startingPosition;
        direction = Position.DirectionTo(destination);
        
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        //direction = Position.DirectionTo(destination);
        GD.Print(Position);
        LinearVelocity = direction*300;
      
        
        if(Position == destination)
        {
            //this.QueueFree();
        }
    }

    public void setStartingPos(Vector2 pos)
    {
        Position = pos;
        startingPosition = pos;
        //GD.Print(Position);
    }
    public void setDestination(Vector2 dest)
    {
        
        destination = dest;
        direction = Position.DirectionTo(destination);
        
    }
}
