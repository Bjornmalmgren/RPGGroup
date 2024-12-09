using Godot;
using System;

public partial class VillageMap : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void PlayerCollision(Node2D body)
	{
		if (body.Name == "Player")
		{
			SceneManager scene = (SceneManager)this.GetParent();
			scene.loadScene("Scenes/ForestMap.tscn");
			int children = scene.GetChildCount();
			for (int i = 0; i < children; i++)
			{
				if (scene.GetChild(i).Name == this.Name)
				{
					scene.unLoadSceneByIndex(i);
					break;
				}
			}
		}
	}
}
