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
        var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
        signalBuss.Connect(SignalBuss.SignalName.Unpause, Callable.From(unpauseGame), (uint)GodotObject.ConnectFlags.Persist);
        signalBuss.Connect(SignalBuss.SignalName.Quit, Callable.From(shutdown), (uint)GodotObject.ConnectFlags.OneShot);
        signalBuss.Connect(SignalBuss.SignalName.PlayerDeath, Callable.From(PlayerDeath), (uint)GodotObject.ConnectFlags.Persist);
        signalBuss.Connect(SignalBuss.SignalName.StartButtonPressed, Callable.From(startGame), (uint)GodotObject.ConnectFlags.OneShot);
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
				GD.Print("Paused");
                frame = 0;
            }
            
			
        }
		frame++;
        if (Input.IsKeyPressed(Key.Escape)&& GetTree().Paused == true&&frame>=120)
        {
            unpauseGame();
            GD.Print("unpause");
			frame = 0;
        }

    }
	void initialize()
	{

	}
	void update(float time) 
	{
	
	}
	void shutdown()
	{
		
		GetTree().Quit();
	}
	GameManager getInstance() { 
		return instance;
	}
	void startGame()
	{
		SceneManager.OnStartButtonPressed();
	}
	void PlayerDeath()
	{
		GD.Print("player died");
		SceneManager.unLoadScenes();
		SceneManager.loadScene("Scenes/startmenu.tscn");
    }
	void pauseGame()
	{
		
		var pauseUi=SceneManager.GetChild(1).GetChild(0).GetChild(0).GetChild(1);
		TextureRect pause = (TextureRect)pauseUi;
		
		pause.Visible = true;
		GetTree().Paused = true;
		
	}
	void unpauseGame()
	{
        var pauseUi = SceneManager.GetChild(1).GetChild(0).GetChild(0).GetChild(1);
        TextureRect pause = (TextureRect)pauseUi;
        pause.Visible = false;
        GetTree().Paused = false;
	}
	void saveGame()
	{

	}
	void loadGame()
	{

	}
	
}
