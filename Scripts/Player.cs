using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public  float Speed = 300.0f;
	
	public void GetInput()
	{
		Vector2 inputDir = Input.GetVector("Left", "Right", "Up", "Down");
		Velocity = inputDir * Speed;
	}
	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
