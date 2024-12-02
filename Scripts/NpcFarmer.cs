using Godot;
using System;

public partial class NpcFarmer : Node2D
{
	private TextEdit interaction_symbol;
	
	public override void _Ready()
	{
	interaction_symbol = GetNode<TextEdit>("Interaction_symbol");
	interaction_symbol.Visible = false;

	}
	public override void _Process(double delta)
	{
	}
	void _on_interaction_area_body_entered(Node body){
		if(body.IsInGroup("player")){
			interaction_symbol.Visible = true;
		}
	}
	void _on_interaction_area_body_exited(Node body){
		if(body.IsInGroup("player")){
			interaction_symbol.Visible = false;
		}
	}
	
}
