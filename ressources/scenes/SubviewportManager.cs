using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public partial class SubviewportManager : Control
{
	[Export] private PackedScene packedScene;
	public static SubviewportManager Instance {get; private set;}
	private Dictionary<OffscreenMarker, Node> offscreenMarkers = new Dictionary<OffscreenMarker, Node>();

    public override void _EnterTree()
    {
        Instance = this;
    }

    internal void ReleaseOffscreenMarker(OffscreenMarker offscreenMarker)
    {
		if(!offscreenMarkers.ContainsKey(offscreenMarker)){
			return;
		}
		
		Debug.WriteLine("remove offscreenmaker");

		offscreenMarkers[offscreenMarker].Free();
        offscreenMarkers.Remove(offscreenMarker);
    }

    internal void RequestOffscreenMarker(OffscreenMarker offscreenMarker)
    {
		if(offscreenMarkers.ContainsKey(offscreenMarker)){
			return;
		}

		Debug.WriteLine("add offscreenmaker");
        OffscreenHint offscreenHint = packedScene.Instantiate<OffscreenHint>();
		offscreenHint.Attach(offscreenMarker);
		AddChild(offscreenHint);
	
		offscreenMarkers.Add(offscreenMarker,offscreenHint);
	}
}
