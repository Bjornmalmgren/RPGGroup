using Godot;
using System;
using System.Numerics;

public partial class Projectile : RigidBody2D
{

    Godot.Vector2 startingPosition;
    Godot.Vector2 destination;
    Godot.Vector2 direction;
    bool applyForce = false;
 
    Godot.Vector2 pos;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
  
		direction = Position.DirectionTo(destination);
		
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        //direction = Position.DirectionTo(destination);
        //GD.Print(Position);


        if (applyForce == true)
        {
            ApplyForce(destination * 200);
        }
        





    
    }

    public void onCollision(Node body)
    {
       
        applyForce = false;
        this.Visible = false;

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

        pos = position;
        RigidBody2D r = this;
        this.Visible = true;
        r.Position = pos;
        LinearVelocity = new Godot.Vector2(0,0);
    }

}
