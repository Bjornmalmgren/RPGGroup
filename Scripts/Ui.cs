using Godot;
using System;

public partial class Ui : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Callable calls = new Callable(this, MethodName.HealthChanged);
        var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
        signalBuss.Connect(SignalBuss.SignalName.PlayerLostHealth,calls, (uint)GodotObject.ConnectFlags.Persist);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ContinuePressed()
	{
		
        var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
        signalBuss.EmitUnpause();
    }
	public void QuitPressed()
	{
		
        var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
		signalBuss.EmitQuit();
    }
	public void HealthChanged(int health)
	{
		
		var healthbar=GetChild(0).GetChild(0).GetChild(0);
		TextureProgressBar healthbars = (TextureProgressBar)healthbar;
		healthbars.Value = health;

    }
}
