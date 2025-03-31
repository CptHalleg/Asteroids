using Godot;
using System;

public partial class FPSDisplay : Label
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Text = "FPS: " + Engine.GetFramesPerSecond();
	}
}
