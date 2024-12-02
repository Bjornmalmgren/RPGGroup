using Godot;
using System;

public partial class NpcFarmer : Node2D
{
	private TextEdit interaction_symbol; 
	
	private int conversation_counter = 0;
	private int quest_state = 0;
	public override void _Ready()
	{
		interaction_symbol = GetNode<TextEdit>("Interaction_symbol");
		interaction_symbol.Visible = false;
		

	}
	public override void _Process(double delta)
	{
		if(interaction_symbol.Visible){
			if(Input.IsActionJustPressed("Interact")){
				GD.Print("works");
				//need to add quest not completed bool
				if(quest_state == 0){
					if (conversation_counter == 0){
						SoundManager.Instance.playConversation("NpcConversationOne");
						}
					if (conversation_counter == 1){
						SoundManager.Instance.playConversation("NpcConversationTwo");
						}
					if (conversation_counter == 2){
						SoundManager.Instance.playConversation("NpcConversationThree");
						}
					if (conversation_counter == 3){
						SoundManager.Instance.playConversation("NpcConversationFour");
						}
					if (conversation_counter == 4){
						SoundManager.Instance.playConversation("RESET");
						conversation_counter = -1;
						quest_state = 1;
					}
						conversation_counter++;
						GD.Print(conversation_counter);
					}
				else if(quest_state == 1){
					SoundManager.Instance.playConversation("NpcConversationFive");
				}
				
				else if(quest_state == 3){
					//when quest is completed
				}
				}
				
			}
		
	}
	void _on_interaction_area_body_entered(Node body){
		if(body.IsInGroup("player")){
			interaction_symbol.Visible = true;
			
		}
	}
	void _on_interaction_area_body_exited(Node body){
		if(body.IsInGroup("player")){
			interaction_symbol.Visible = false;
			SoundManager.Instance.playConversation("RESET");
		}
	}
	
}
