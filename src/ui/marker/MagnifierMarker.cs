using Godot;
using System;

public partial class MagnifierMarker : Node2D
{
	[Export] private PackedScene magnifierScene;
	[Export] public Polygon2D Polygon2D;
	private Magnifier magnifier;

	public override void _Ready()
	{
		magnifier = magnifierScene.Instantiate<Magnifier>();
		OverlayUI.Instance.AddChild(magnifier);
		magnifier.Attach(this);
	}

    public override void _ExitTree()
    {
		magnifier.QueueFree();
    }
}
