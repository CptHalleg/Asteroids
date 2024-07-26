using Godot;
using System;
using System.Diagnostics;

public partial class OutlineLine2D : Line2D
{
	public void CopyPoints(Polygon2D polygon2D)
	{
		Debug.WriteLine(Points == null);
		Points = polygon2D.Polygon;
	}
}
