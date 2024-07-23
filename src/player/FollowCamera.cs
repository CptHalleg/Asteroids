using Godot;
using System;
using System.Diagnostics;

public partial class FollowCamera : Camera2D
{
	[Export]
	public Node2D Following;

	public override void _Process(double delta)
	{
		if(IsInstanceValid(Following)) {
			GlobalPosition = Following.GlobalPosition;
		}
	}
}
