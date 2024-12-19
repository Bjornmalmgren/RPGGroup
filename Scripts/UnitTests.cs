using Godot;
using System;
using GdUnit4;
using static GdUnit4.Assertions;

[TestSuite]
public partial class UnitTests
{
    static PackedScene scenePlayer = GD.Load<PackedScene>("res://Scenes/player.tscn");
    Player player = scenePlayer.Instantiate<Player>();

    static PackedScene sceneEnemy = GD.Load<PackedScene>("res://Scenes/Enemy.tscn");
    Enemy enemy = sceneEnemy.Instantiate<Enemy>();

    static PackedScene sceneVillage = GD.Load<PackedScene>("res://Scenes/VillageMap.tscn");
    villageScene village = sceneVillage.Instantiate<villageScene>();

    static PackedScene sceneForest = GD.Load<PackedScene>("res://Scenes/ForestMap.tscn");
    ForestMap forest = sceneForest.Instantiate<ForestMap>();

    

    SignalBuss signal = new SignalBuss();



    [TestCase]
    public void ReduceHealthTest()
    {
        AssertInt(player.health).IsNotZero();
        player.reduceHealth(-25);

        AssertInt(player.health).IsEqual(75);
        player.reduceHealth(25);
        AssertInt(player.health).IsEqual(50);

    }
    [TestCase]
    public void EnemyReduceHealthTest()
    {
        AssertInt(enemy.health).IsNotZero();
        enemy.reduceHealth(-2);
        AssertInt(enemy.health).IsEqual(10);
        enemy.reduceHealth(-7);
        AssertInt(enemy.health).IsEqual(3);
    }
    [TestCase]
    public void PlayerPositionTest()
    {

        AssertVector(player.Position).IsBetween(new Vector2(-3000, -600), new Vector2(3000, 1200));
    }
    [TestCase]
    public void SignalTest()
    {
        
        AssertSignal(enemy).IsSignalExists("body_entered");
        AssertSignal(enemy).IsSignalExists("body_exited");
        AssertSignal(signal).IsSignalExists("PlayerAttacked");
        AssertSignal(signal).IsSignalExists("PlayerAttack");
        AssertSignal(signal).IsSignalExists("EnemyHit");
        AssertSignal(signal).IsSignalExists("PlayerLostHealth");
        AssertSignal(signal).IsSignalExists("PlayerDeath");



        AssertSignal(signal).IsSignalExists("ForestMapChange");
        AssertSignal(signal).IsSignalExists("VillageMapChange");
       
        

    


    }
}
