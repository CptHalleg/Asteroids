using Godot;
using System;

public partial class Magnifier : Control
{
	private OutlineLine2D outlineLine2D;
	private MagnifierMarker attached;

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Visible = GetViewport().GetCamera2D().Zoom.Length() < 0.2f;
		
		GlobalPosition = GetViewport().CanvasTransform * attached.GlobalPosition;
		Rotation = attached.GlobalRotation;
	}

    internal void Attach(MagnifierMarker magnifierMarker)
    {
		outlineLine2D = GetChild<OutlineLine2D>(0);
		this.attached = magnifierMarker;
		outlineLine2D.CopyPoints(magnifierMarker.Polygon2D);
    }

}
