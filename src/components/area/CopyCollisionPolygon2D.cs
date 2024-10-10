using Godot;
using System;
using System.Diagnostics;

public partial class CopyCollisionPolygon2D : CollisionPolygon2D
{
	[Export] public Polygon2D Polygon2D;
	public override void _EnterTree()
	{
		Polygon = Polygon2D.Polygon;
	}
}
