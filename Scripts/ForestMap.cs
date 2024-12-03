using Godot;
using System;

public partial class ForestMap : Node2D
{
		private readonly Vector2[] enemySpawnPositions = 
	{
		new Vector2(0, 24),
		new Vector2(30, 40),
		new Vector2(50, 10)
	};
	
	private EnemyManager enemyManager;
	
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
	}
	
	private void SpawnEnemies()
	{
		foreach (Vector2 spawnPosition in enemySpawnPositions)
		{
			// Spawna en fiende via EnemyManager
			Enemy enemy = enemyManager.spawnEnemy("DefaultEnemy");

			if (enemy != null)
			{
				// Sätt fiendens position och lägg till den som barn till kartan
				enemy.Position = spawnPosition;
				AddChild(enemy);
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
