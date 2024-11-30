using Godot;
using System;

public partial class Startmenu : MarginContainer
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	void OnStartPressed()
	{

		var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
		signalBuss.EmitStartButtonPressed();

		GD.Print("yes");
		

	}
	void OnQuitPressed()
	{
		GD.Print("no");
		GetTree().Quit();
	}
}
