using Godot;
using System;

public partial class Gyroscope : Node
{
	[Export] public float RotationSpeed = 1;
	private Ship ship;

    public override void _Ready()
    {
        ship = GetParent<Ship>();
    }

    public override void _Process(double delta)
    {
        ship.Rotation += (float)delta * RotationSpeed * ship.ControlRotating;
    }
}
