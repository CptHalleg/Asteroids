using Godot;
using System;
using System.Diagnostics;

public partial class CopyCollisionPolygon2D : CollisionPolygon2D
{
	[Export] public Polygon2D Polygon2D;
	public override void _EnterTree()
	{
		if(Polygon2D == null){
			Debug.WriteLine(GetPath());
		}
		Polygon = Polygon2D.Polygon;
	}
}
