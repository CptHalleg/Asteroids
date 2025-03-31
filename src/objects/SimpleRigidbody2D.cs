using Godot;
using System;

public partial class SimpleRigidbody2D : Node2D
{
	[Export] public Vector2 Velocity;
	[Export] public float RotationSpeed;

    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition += Velocity * (float) delta;
        GlobalRotation += RotationSpeed * (float) delta;
     }
}
