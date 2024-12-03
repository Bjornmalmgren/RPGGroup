using Godot;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public partial class EnemyManager : Node
{
	
	[Export] private PackedScene enemyPrefab;
	
	private List<Enemy> enemies = new List<Enemy>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (enemyPrefab == null)
		{
			GD.PrintErr("Enemy prefab is not set in the EnemyManager script!");
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public Enemy spawnEnemy(string type)
	{
		if (enemyPrefab == null)
		{
			return null;
		}

		Enemy enemy = (Enemy)enemyPrefab.Instantiate();
		enemies.Add(enemy);

		return enemy;
	}
	
	void updateEnemies()
	{
		foreach (Enemy enemy in enemies)
		{
			//Gör något med fienderna!
		}
	}

	void removeEnemy(Enemy enemy)
	{
		if (enemies.Contains(enemy))
		{
			enemies.Remove(enemy);
			enemy.QueueFree();
		}
	}
}
