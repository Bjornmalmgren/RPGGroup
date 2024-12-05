using Godot;
using System;
using static System.Formats.Asn1.AsnWriter;

public partial class ForestMap : Node2D
{
	
	private readonly Vector2[] enemySpawnPositions = 
	{
		new Vector2(0, 24),
		new Vector2(30, 40),
		new Vector2(50, 10)
	};
	
	private EnemyManager enemyManager;
	
	private void SpawnEnemies()
	{
		foreach (Vector2 spawnPosition in enemySpawnPositions)
		{
			Enemy enemy = enemyManager.spawnEnemy("WolfEnemy");

			if (enemy != null)
			{
				enemy.Position = spawnPosition;
				AddChild(enemy);
			}
		}
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.PrintErr("ForestMap loaded and ready!");
		enemyManager = GetNode<EnemyManager>("EnemyManager");

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
