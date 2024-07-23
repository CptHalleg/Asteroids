using Godot;
using System;
using System.ComponentModel;
using System.Diagnostics;

public partial class OffscreenHint : Control
{
	private FollowCamera followCamera;
	private Node2D Attached;
	private Camera2D camera2D;
	private Viewport viewport;

	public void Attach(OffscreenMarker offscreenMarker){
		viewport = World.Instance.GetViewport();
        camera2D = viewport.GetCamera2D();
		followCamera = GetChild(1).GetChild(0).GetChild<FollowCamera>(0);
		followCamera.Zoom = new Vector2(offscreenMarker.Zoom, offscreenMarker.Zoom);
		followCamera.Following = offscreenMarker;
		Attached = offscreenMarker;
	}

    public override void _Process(double delta)
    {
        Vector2 screenSize = viewport.GetVisibleRect().Size;
		screenSize -= new Vector2(200,200);

		Vector2 directionToTarget = (Attached.GlobalPosition - camera2D.GlobalPosition).Normalized();
		directionToTarget *= screenSize.X+ screenSize.Y;
		directionToTarget.X = Mathf.Clamp(directionToTarget.X, -screenSize.X/2, screenSize.X/2);
		directionToTarget.Y = Mathf.Clamp(directionToTarget.Y, -screenSize.Y/2, screenSize.Y/2);

		Position = directionToTarget + new Vector2(screenSize.X/2, screenSize.Y/2);
    }
}
