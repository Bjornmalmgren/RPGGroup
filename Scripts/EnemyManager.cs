using Godot;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public partial class EnemyManager : Node
{
	
	[Export] private PackedScene enemyPrefabWolf;
	[Export] private PackedScene enemyPrefabCultist;
	public static EnemyManager Instance { get; private set; }
	private List<Enemy> enemies = new List<Enemy>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		if (enemyPrefabWolf == null || enemyPrefabCultist == null )
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
		PackedScene selectedPrefab = null;
		if (type == "WolfEnemy")
		{
			selectedPrefab = enemyPrefabWolf;
		}
		else if (type == "CultistEnemy")
		{
			selectedPrefab = enemyPrefabCultist;
		}

		if (selectedPrefab == null)
		{
			GD.PrintErr("No enemy prefab found for type: " + type);
			return null;
		}

		Enemy enemy = (Enemy)selectedPrefab.Instantiate();
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
