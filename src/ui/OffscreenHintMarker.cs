using Godot;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class OffscreenHintMarker : Area2D
{
	[Export] public float Zoom;
    [Export] public PackedScene OffscreenHintScene;
    private int currentViewingCams;
    private bool firstFrame = false;
    private OffscreenHint offscreenHint;
    private bool hitAddedAsChild = false;

    public async override void _Ready()
	{
		AreaEntered += OnScreenEntered;
		AreaExited += OnScreenExited;

        offscreenHint = OffscreenHintScene.Instantiate<OffscreenHint>();
        offscreenHint.Attach(this);
        //idk why i have tp wait twice
        await ToSignal( GetTree(),SceneTree.SignalName.PhysicsFrame); 
        await ToSignal( GetTree(),SceneTree.SignalName.PhysicsFrame); 
        if(currentViewingCams == 0 && !hitAddedAsChild){
            OverlayUI.Instance.AddChild(offscreenHint);
            hitAddedAsChild = true;
        }
    }

    private void OnScreenEntered(Area2D area2D)
    {
        if(currentViewingCams == 0 && hitAddedAsChild){
            OverlayUI.Instance.RemoveChild(offscreenHint);
            hitAddedAsChild = false;
        }
        currentViewingCams++;

    }


    private void OnScreenExited(Area2D area2D)
    {
        if(currentViewingCams == 1 && !hitAddedAsChild){
            OverlayUI.Instance.AddChild(offscreenHint);
            hitAddedAsChild = true;
        }
        currentViewingCams--;
    }

    public override void _ExitTree()
    {
        offscreenHint.QueueFree();
    }

}
