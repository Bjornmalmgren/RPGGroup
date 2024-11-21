using Godot;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public partial class EnemyManager : Node
{
	
	List<Enemy> enemies;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	Enemy spawnEnemy(string type)
	{
		return enemies[0];
	}
	void updateEnemies()
	{

	}

	void removeEnemy(Enemy enemy)
	{

	}
}
