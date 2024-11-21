using Godot;
using System;

public partial class StatsManager : Node
{
	int enemiesKilled;
	int money;
	int playerHP;
	int playerSpeed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	StatsManager getInstance()
	{
		return this;
	}

	int getStat(string statName)
	{
		return enemiesKilled;
	}

	void setStat(string statName, int value)
	{

	}

	void resetStats()
	{

	}
}
