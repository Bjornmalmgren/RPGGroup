using Godot;
using System;
using static System.Formats.Asn1.AsnWriter;

public partial class SceneManager : Node
{
	string currentScene;
	public bool startSceneLoaded = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		loadScene("Scenes/startmenu.tscn");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnStartButtonPressed()
	{
		GD.Print("no");
		unLoadScenes();
	 
		loadScene("Scenes/VillageMap.tscn");
	  
		loadScene("Scenes/player.tscn");
		AddScene("Scenes/Enemy.tscn");
		loadScene("Scenes/UI.tscn");

		startSceneLoaded = true;
	}
	public void loadScene(string sceneName)
	{
		if(currentScene!=sceneName)
		{
			var child = GD.Load<PackedScene>(sceneName);
			var instance = child.Instantiate();
			AddChild(instance);
			currentScene= sceneName;
		}
		
	}
	public void unLoadScenes()
	{
		
		var children = GetChildren();
		foreach (var child in children)
		{
			RemoveChild(child);
		}
	}
	public void unLoadSceneByName(string name)
	{

		var children = GetChildren();
		foreach (var child in children)
		{
			if (child.Name == name)
			{
				RemoveChild(child);
			}

		}
	}
	
	public void unLoadSceneByIndex(int index)
	{
		
		var child = GetChild(index);
		RemoveChild(child);
	}
	void AddScene(string sceneName)
	{
		if (currentScene != sceneName)
		{
			var children= GetChildren();
			var mapchild = GetChild(0);
			foreach(var child in children){
				if(child.GetGroups().Contains("maps"))
				{
					GD.Print(child.Name);

					mapchild = child;
					break;
				}
			}

			var grandchild = GD.Load<PackedScene>(sceneName);
			var instance = grandchild.Instantiate();
			mapchild.AddChild(instance);

		}
	}
	public void AddSceneTo(string sceneName,Node2D node)
 	{
		
		if (currentScene != sceneName)
		{
			var child = GD.Load<PackedScene>(sceneName);
			var instance = child.Instantiate();
			node.AddChild(instance);

		}
  	}
}
