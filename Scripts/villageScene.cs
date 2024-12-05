using Godot;
using System;
using static System.Formats.Asn1.AsnWriter;

public partial class villageScene : Node
{
	private EnemyManager enemyManager;
	private void SpawnEnemies()
	{
			// Locate the parent node of all spawn points
		Node spawnPointsParent = GetNode("SpawnPoints");
		
		if (spawnPointsParent == null)
		{
			GD.PrintErr("No 'SpawnPoints' node found in the scene!");
			return;
		}
		
		// Iterate over all child nodes of SpawnPoints
		foreach (Node child in spawnPointsParent.GetChildren())
		{
			if (child is Node2D spawnPoint)
			{
				Enemy enemy = null;

				// Spawn wolf or cultist based on spawn point name or group
				if (((string)spawnPoint.Name).Contains("Wolf"))
				{
					enemy = enemyManager.spawnEnemy("WolfEnemy");
				}
				if (((string)spawnPoint.Name).Contains("Cultist"))
				{
					enemy = enemyManager.spawnEnemy("CultistEnemy");
				}

				// If an enemy was spawned, set its position and add it to the scene
				if (enemy != null)
				{
					enemy.Position = spawnPoint.GlobalPosition;
					AddChild(enemy);
					GD.Print($"Spawned {enemy.Name} at {enemy.Position}");
				}
			}
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		enemyManager = GetNode<EnemyManager>("/root/EnemyManager");

		if (enemyManager == null)
		{
			GD.PrintErr("EnemyManager not found in the scene!");
			return;
		}
		Callable calls = new Callable(this, MethodName.WaitUntillForestLoaded);
		var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
		signalBuss.Connect(SignalBuss.SignalName.ForestMapChange, calls, (uint)GodotObject.ConnectFlags.Persist);
		SceneManager scene = (SceneManager)this.GetParent();
	  	SpawnEnemies();
		if (scene.startSceneLoaded == true)
		{
			signalBuss.EmitVillageMapChange();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void playerCollision(Node2D body)
	{

		if (body.Name == "Player")
		{
			SceneManager scene = (SceneManager)this.GetParent();
			scene.CallDeferred(SceneManager.MethodName.loadScene, "Scenes/ForestMap.tscn");
		}
			


	}

	public void WaitUntillForestLoaded()
	{
		// GD.Print("aaa");
		SceneManager scene = (SceneManager)this.GetParent();
		int children = scene.GetChildCount();
		int player = 2;
		int forestMap = 2;
		for (int i = 0; i < children; i++)
		{
			if (scene.GetChild(i).Name == "Player")
			{
				player = i;


			}
			if (scene.GetChild(i).Name == "Forest")
			{

				forestMap = i;
			}
		}

		Player rig = (Player)scene.GetChild(player);
		Node2D pos = (Node2D)scene.GetChild(forestMap).GetChild(6).GetChild(1);
		//GD.Print(scene.GetChild(forestMap).Name);
		for (int i = 0; i < children; i++)
		{
			if (scene.GetChild(i).Name == this.Name)
			{
				scene.CallDeferred(SceneManager.MethodName.unLoadScene, i);

				rig.Position = pos.Position;
				break;
			}
		}
	}
}
