using Godot;
using System;
using static System.Formats.Asn1.AsnWriter;

public partial class ForestMap : Node2D
{
	private readonly Vector2[] wolfSpawnPositions = 
	{
		new Vector2(-2430, 350),
		new Vector2(960, -730),
		new Vector2(0, -170),
		new Vector2(-1030, 1080),
		new Vector2(-570, 2280),
		new Vector2(3173, 265)
	};
	
	private readonly Vector2[] cultistSpawnPositions = 
	{
		new Vector2(-280, -1343)
	};
	
	private EnemyManager enemyManager;
	
	private void SpawnEnemies()
	{
		foreach (Vector2 spawnPosition in wolfSpawnPositions)
		{
			Enemy wolf = enemyManager.spawnEnemy("WolfEnemy");

			if (wolf != null)
			{
				wolf.Position = spawnPosition;
				GD.Print($"Spawning enemy at: {spawnPosition}");
				AddChild(wolf);
			}
		}
		foreach (Vector2 spawnPosition in cultistSpawnPositions)
		{
			Enemy cultist = enemyManager.spawnEnemy("CultistEnemy");

			if (cultist != null)
			{
				cultist.Position = spawnPosition;
				AddChild(cultist);
			}
		}
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.PrintErr("ForestMap loaded and ready!");
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
		GD.Print(scene.GetChild(villageMap).GetChild(10).GetChild(1).Name);
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
