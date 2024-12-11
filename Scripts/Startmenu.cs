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
		//Sends signal through the signalbuss to tell the game to start
		var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
		signalBuss.EmitStartButtonPressed();

		
		

	}
	void OnQuitPressed()
	{
		
		var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
		signalBuss.EmitQuit();
	}
}
