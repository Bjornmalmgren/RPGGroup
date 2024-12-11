using Godot;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public partial class EnemyManager : Node
{
	// Drag-and-drop the Wolf enemy scene into the field "enemyPrefabWolf" that is now in the editor
	[Export] private PackedScene enemyPrefabWolf;
	// Drag-and-drop the Wolf enemy scene into the field "enemyPrefabCultist" that is now in the editor
	[Export] private PackedScene enemyPrefabCultist;
	// Singleton pattern for global access to the EnemyManager
	public static EnemyManager Instance { get; private set; }
	// List to keep track of all spawned enemies
	private List<Enemy> enemies = new List<Enemy>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Assigning Instance to this object
		Instance = this;
		//Check if enemyPrefabWolf is assigned
		if (enemyPrefabWolf == null)
		{
			GD.PrintErr("Wolf: Enemy prefab is not set in the EnemyManager script!");
		}
		//Check if enemyPrefabCultist is assigned
		if (enemyPrefabCultist == null )
		{
			GD.PrintErr("Enemy prefab is not set in the EnemyManager script!");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	//Method to spawn enemies
	public Enemy spawnEnemy(string type)
	{
		// Determine which prefab that is currently to be used
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
		// Instantiate the selected prefab and cast it to the Enemy type
		Enemy enemy = (Enemy)selectedPrefab.Instantiate();
		// Add the newly spawned enemy to the list of enemies
		enemies.Add(enemy);
		// Return the instantiated enemy
		return enemy;
	}
	
	// Method for removing an enemy from the game 
	void removeEnemy(Enemy enemy)
	{
		// Check of the enemy is in the enemy list
		if (enemies.Contains(enemy))
		{
			// Remove the enemy from the list
			enemies.Remove(enemy);
			// delete the enemy from the scen
			enemy.QueueFree();
		}
	}
}
