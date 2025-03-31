using Godot;
using System;
using System.Diagnostics;

public partial class FollowCamera : Camera2D
{
	[Export] public Node2D Following;
	[Export] public float MovementScale = 1;
	public override void _Ready()
	{
		if (Following == null)
			Following = PlayerController.playerShip;
	}

	public override void _Process(double delta)
	{
		Vector2 screenSize = GetViewport().GetVisibleRect().Size;
		Vector2 mousePos = GetViewport().GetMousePosition();
		mousePos.X = Mathf.Clamp(mousePos.X, 0, GetViewport().GetVisibleRect().Size.X);
		mousePos.Y = Mathf.Clamp(mousePos.Y, 0, GetViewport().GetVisibleRect().Size.Y);
		Vector2 relativeMousePos = mousePos - (screenSize / 2);
		relativeMousePos.X = relativeMousePos.X / Zoom.X;
		relativeMousePos.Y = relativeMousePos.Y / Zoom.Y;
		if (IsInstanceValid(Following))
		{
			GlobalPosition = Following.GlobalPosition + relativeMousePos * MovementScale;
		}
	}
}
