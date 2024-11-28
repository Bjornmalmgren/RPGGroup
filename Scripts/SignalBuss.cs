using Godot;
using System;

public partial class SignalBuss : Node
{
	[Signal]
	public delegate void StartButtonPressedEventHandler();

	[Signal]
	public delegate void PlayerAttackEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void EmitStartButtonPressed()
	{
		GD.Print("yes");
		EmitSignal(nameof(StartButtonPressed));

	}
	public void EmitPlayerAttack()
	{

	}
}