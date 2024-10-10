using Godot;
using System;

public partial class CameraZoom : Node
{
	private Camera2D camera2D;

    public override void _Ready()
    {
        camera2D = GetParent<Camera2D>();
    }

    public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("camera_zoom_in")){
			camera2D.Zoom *= 1.1f;
		}

		if(Input.IsActionJustPressed("camera_zoom_out")){
			camera2D.Zoom *= 0.9f;
		}
	}
}
