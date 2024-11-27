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
	bool isPaused = false;
	int frame = 0;
	GameManager instance;

	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsMouseButtonPressed(MouseButton.Left) && frame >= 120) {
			frame = 0;
            
            ProjectileManager.spawnProjectile(new Vector2(1, 1), new Vector2(10, 10));
			
        }
		if(frame >= 120)
		{
            
            Projectile p = (Projectile)ProjectileManager.GetChild(0);
            p.Position = new Vector2(-10, -10);
			p.LinearVelocity = new Vector2(0,0);
            p.setStartingPos(new Vector2(-10, -10));
            p.setDestination(new Vector2(-10, -10));

        }
		frame++;
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
	GameManager getInstance() { 
		return instance;
	}
	void startGame()
	{

	}
	void pauseGame()
	{

	}
	void saveGame()
	{

	}
	void loadGame()
	{

	}
	void endGame()
	{

	}
}
