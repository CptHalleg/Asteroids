using Godot;
using System;

[GlobalClass]
public partial class FireingArc : Node2D
{
	[Export] public float MaxAngle = 1;
	[Export] public float Range = 1000;
	[Export] public bool DisplayRange = false;

    public bool ContainsAngle(Vector2 directionToTarget)
    {
        return Mathf.Abs(directionToTarget.AngleTo(GlobalTransform.BasisXform(Vector2.Up))) < MaxAngle;
    }
}
