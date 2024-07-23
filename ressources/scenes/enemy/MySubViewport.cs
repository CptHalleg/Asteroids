using Godot;
using System;

public partial class MySubViewport : Godot.SubViewport
{
	public override void _Ready()
	{
		World2D = World.Instance.GetViewport().World2D;
	}
}
