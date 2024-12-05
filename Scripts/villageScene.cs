using Godot;
using System;
using static System.Formats.Asn1.AsnWriter;

public partial class villageScene : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Callable calls = new Callable(this, MethodName.WaitUntillForestLoaded);
        var signalBuss = GetNode<SignalBuss>("/root/SignalBuss");
        signalBuss.Connect(SignalBuss.SignalName.ForestMapChange, calls, (uint)GodotObject.ConnectFlags.Persist);
        SceneManager scene = (SceneManager)this.GetParent();
      
        if (scene.startSceneLoaded == true)
        {
            signalBuss.EmitVillageMapChange();
        }
        
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void playerCollision(Node2D body)
    {

        if (body.Name == "Player")
        {
            SceneManager scene = (SceneManager)this.GetParent();
            scene.CallDeferred(SceneManager.MethodName.loadScene, "Scenes/ForestMap.tscn");
        }
            


    }

    public void WaitUntillForestLoaded()
    {
        // GD.Print("aaa");
        SceneManager scene = (SceneManager)this.GetParent();
        int children = scene.GetChildCount();
        int player = 2;
        int forestMap = 2;
        for (int i = 0; i < children; i++)
        {
            if (scene.GetChild(i).Name == "Player")
            {
                player = i;


            }
            if (scene.GetChild(i).Name == "Forest")
            {

                forestMap = i;
            }
        }

        Player rig = (Player)scene.GetChild(player);
        Node2D pos = (Node2D)scene.GetChild(forestMap).GetChild(6).GetChild(1);
        //GD.Print(scene.GetChild(forestMap).Name);
        for (int i = 0; i < children; i++)
        {
            if (scene.GetChild(i).Name == this.Name)
            {
                scene.CallDeferred(SceneManager.MethodName.unLoadScene, i);

                rig.Position = pos.Position;
                break;
            }
        }
    }
}
