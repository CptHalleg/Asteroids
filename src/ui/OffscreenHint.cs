using Godot;
using System;
using System.ComponentModel;
using System.Diagnostics;

public partial class OffscreenHint : Control
{
	private int borderWidth = 20;
	private FollowCamera attachedCamera;
	private Node2D Attached;
	private Control rotor;

	public void Attach(OffscreenHintMarker offscreenMarker){
		rotor = GetChild<Control>(0);
		attachedCamera = GetChild(0).GetChild(1).GetChild(0).GetChild<FollowCamera>(0);
		attachedCamera.Zoom = new Vector2(offscreenMarker.Zoom, offscreenMarker.Zoom);
		attachedCamera.Following = offscreenMarker;
		Attached = offscreenMarker;
	}

    public override void _Process(double delta)
    {
		if(!IsInstanceValid(Attached)){
			QueueFree();
			return;
		}
		GlobalPosition = GetViewport().CanvasTransform * Attached.GlobalPosition;
		Vector2 border = new Vector2(borderWidth, borderWidth);
		GlobalPosition = GlobalPosition.Clamp(border, GetViewport().GetVisibleRect().Size - border);

		Rotation = (Attached.GlobalPosition - GetViewport().GetCamera2D().GlobalPosition).Angle();
		rotor.Rotation = -Rotation;
    }
}
