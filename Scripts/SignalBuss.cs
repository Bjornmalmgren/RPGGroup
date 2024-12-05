using Godot;
using System;

public partial class SignalBuss : Node
{
	[Signal]
	public delegate void StartButtonPressedEventHandler();

	[Signal]
	public delegate void PlayerAttackEventHandler(Vector2 startPos,Vector2 destination);

	[Signal]
	public delegate void PlayerAttackedEventHandler(int damage);
    [Signal]
    public delegate void PlayerLostHealthEventHandler(int health);
    [Signal]
    public delegate void EnemyHitEventHandler(int damage);
    [Signal]
	public delegate void UnpauseEventHandler();
    [Signal]
    public delegate void QuitEventHandler();
    [Signal]
    public delegate void PlayerDeathEventHandler();
    [Signal]
    public delegate void ForestMapChangeEventHandler();
    [Signal]
    public delegate void VillageMapChangeEventHandler();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void EmitStartButtonPressed()
	{
		
		EmitSignal(nameof(StartButtonPressed));

	}
	public void EmitPlayerAttack(Vector2 startPos, Vector2 Dest)
	{
		
		
		EmitSignal(nameof(PlayerAttack),startPos,Dest);
	}
	public void EmitPlayerAttacked(int damage)
	{
		//GD.Print(damage);
		EmitSignal(nameof(PlayerAttacked),damage);
	}
	public void EmitPlayerLostHealth(int health)
	{
		EmitSignal(nameof(PlayerLostHealth),health);
	}
	public void EmitUnpause()
	{
		EmitSignal(nameof(Unpause));
	}
	public void EmitQuit()
	{
		EmitSignal(nameof(Quit));
	}
	public void EmitPlayerDeath()
	{
		EmitSignal(nameof(PlayerDeath));
	}
	public void EmitEnemyHit(int damage)
	{
		EmitSignal(nameof(EnemyHit),damage);
	}

	public void EmitForestMapChange()
	{
		EmitSignal(nameof(ForestMapChange));
	}
    public void EmitVillageMapChange()
    {
        EmitSignal(nameof(VillageMapChange));
		//GD.Print("a");
    }
}