using Godot;
using System;

public partial class SceneManager : Node
{
	string currentScene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		loadScene("Scenes/startmenu.tscn");
		var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
		signalBuss.Connect(SignalBuss.SignalName.StartButtonPressed, Callable.From(OnStartButtonPressed), (uint)GodotObject.ConnectFlags.OneShot);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void OnStartButtonPressed()
	{
		GD.Print("no");
		unLoadScene();
		loadScene("Scenes/VillageMap.tscn");
		AddScene("Scenes/player.tscn");
		//AddScene("Scenes/UI.tscn");
	}
	void loadScene(string sceneName)
	{
		if(currentScene!=sceneName)
		{
            var child = GD.Load<PackedScene>(sceneName);
            var instance = child.Instantiate();
            AddChild(instance);
			currentScene= sceneName;
        }
		
	}
	void unLoadScene()
	{
        var children = GetChildren();
        foreach (var child in children)
        {
            RemoveChild(child);
        }
    }
	void AddScene(string sceneName)
	{
		if (currentScene != sceneName)
		{
			var child = GetChild(0);

            var grandchild = GD.Load<PackedScene>(sceneName);
			var instance = grandchild.Instantiate();
			child.AddChild(instance);

        }
    }
	
}