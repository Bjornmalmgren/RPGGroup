using Godot;
using System;

public partial class SoundManager : Node
{
	
	public static SoundManager Instance { get; private set; }
	public AnimationPlayer _animationPlayer;
	private Node2D npc;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void playConversation(string name){
		GD.Print("manager works");
		if(_animationPlayer.IsPlaying()){
			_animationPlayer.Stop();
		}
		if(!_animationPlayer.IsPlaying()){
			_animationPlayer.Play(name);
		}
		
		
		
	}
}
