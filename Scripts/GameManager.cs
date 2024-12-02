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
		//if(Input.IsMouseButtonPressed(MouseButton.Left) && frame >= 120) {
		//	frame = 0;

		//          ProjectileManager.spawnProjectile(new Vector2(1, 1), new Vector2(10, 10));

		//      }
		if(frame >= 120)
		{
            if (Input.IsKeyPressed(Key.Escape) && GetTree().Paused == false)
            {
                pauseGame();
            }
            if (Input.IsKeyPressed(Key.Escape) && GetTree().Paused == true)
            {
                unpauseGame();
            }

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
		GD.Print("yes");
		var pauseUi=SceneManager.GetChild(1);
		CanvasLayer pause = (CanvasLayer)pauseUi;
		pause.Visible = true;
		GetTree().Paused = true;
		
	}
	void unpauseGame()
	{
        var pauseUi = SceneManager.GetChild(1);
        CanvasLayer pause = (CanvasLayer)pauseUi;
        pause.Visible = false;
        GetTree().Paused = false;
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
