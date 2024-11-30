using Godot;
using System;
using System.Numerics;

public partial class Projectile : RigidBody2D
{
    Godot.Vector2 startingPosition;
    Godot.Vector2 destination;
    Godot.Vector2 direction;
    bool applyForce = false;
    bool setposition = false;
    Godot.Vector2 pos;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
  
        direction = Position.DirectionTo(destination);
        
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	//public override void _Process(double delta)
	//{
 //       //direction = Position.DirectionTo(destination);
 //       //GD.Print(Position);

      


 //       if (Position == destination)
 //       {
 //           //this.QueueFree();
 //       }
 //   }

    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        if (setposition)
        {
            Transform2D t;
            t = new Transform2D(new Godot.Vector2(pos.X, pos.Y), new Godot.Vector2(pos.X, pos.Y), new Godot.Vector2(pos.X, pos.Y));
            state.Transform = t;
            setposition = false;
        }
        if (applyForce)
        {
            state.ApplyForce(destination * 20);
            
        }
        else
        {
            //state.ApplyForce(new Godot.Vector2());
        }
        
        
    }

    public void setStartingPos(Godot.Vector2 pos)
    {

        startingPosition = pos;
        //GD.Print(Position);
    }
    public void setDestination(Godot.Vector2 dest)
    {
        applyForce = true;
        destination = dest;
        direction = Position.DirectionTo(destination);
        

    }

    public void setPosition(Godot.Vector2 position)
    {
        setposition = true;
        pos = position;
    }
}
