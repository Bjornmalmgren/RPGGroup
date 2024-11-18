using Godot;
using System;

public partial class GameManager : Node2D
{
	[Export]
	SceneManager SceneManager { get; set; }
    [Export]
	EnemyManager EnemyManager { get; set; }
    [Export]
	UIManager UIManager { get; set; }
    [Export]
	ResourceManager ResourceManager { get; set; }
    [Export]
	AudioManager AudioManager { get; set; }
    [Export]
	ProjectileManager ProjectileManager { get; set; }
    [Export]
	VFXManager VFXManager { get; set; }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	void initialize()
	{

	}
	void update(float time) 
	{
	
	}
	void shutdown()
	{

	}

}
