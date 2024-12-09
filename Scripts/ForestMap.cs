using Godot;
using System;
using static System.Formats.Asn1.AsnWriter;

public partial class ForestMap : Node2D
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
		
		SpawnEnemies();
		
		Callable calls = new Callable(this, MethodName.WaitUntillVillageLoaded);
		var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
		
		signalBuss.Connect(SignalBuss.SignalName.VillageMapChange, calls, (uint)GodotObject.ConnectFlags.Persist);
		SceneManager scene = (SceneManager)this.GetParent();
		if (scene.startSceneLoaded == true)
		{
			signalBuss.EmitForestMapChange();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void PlayerCollision(Node2D body)
	{
		if(body.Name == "Player")
		{
			SceneManager scene = (SceneManager)this.GetParent();
			
			scene.CallDeferred(SceneManager.MethodName.loadScene, "Scenes/VillageMap.tscn");
		   
		}
	}
	public void WaitUntillVillageLoaded()
	{
	   
		SceneManager scene = (SceneManager)this.GetParent();
		int children = scene.GetChildCount();
		int player = 2;
		int villageMap = 2;
		for (int i = 0; i < children; i++)
		{
			if (scene.GetChild(i).Name == "Player")
			{
				player = i;

				
			}
			if (scene.GetChild(i).Name == "Village")
			{
				villageMap = i;
			}
		}

		Player rig = (Player)scene.GetChild(player);
		Node2D pos = (Node2D)scene.GetChild(villageMap).GetChild(10).GetChild(1);
		GD.Print(pos.GlobalPosition);
		for (int i = 0; i < children; i++)
		{
			if (scene.GetChild(i).Name == this.Name)
			{
				scene.CallDeferred(SceneManager.MethodName.unLoadSceneByIndex, i);

				rig.Position = pos.GlobalPosition;
				break;
			}
		}
	}
}
