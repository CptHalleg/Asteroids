using Godot;
using System;
using System.Diagnostics;

public partial class CameraVisibilityArea : Area2D
{
	private Camera2D camera2D;
	private RectangleShape2D rectangleShape2D;
	public override void _Ready()
    {
		rectangleShape2D = new RectangleShape2D();
		CollisionShape2D collisionShape2D = new CollisionShape2D{Shape = rectangleShape2D};
		AddChild(collisionShape2D);
		camera2D = GetParent<Camera2D>();
    }

    public override void _Process(double delta)
    {
        rectangleShape2D.Size = GetViewportRect().Size / camera2D.Zoom;
    }
}
