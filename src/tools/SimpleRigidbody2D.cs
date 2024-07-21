using Godot;
using System;

public partial class SimpleRigidbody2D : Node2D
{
	public Vector2 Velocity;

    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition += Velocity * (float) delta;
    }
}
