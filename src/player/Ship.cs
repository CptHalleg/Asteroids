using Godot;
using System;

public partial class Ship : SimpleRigidbody2D
{
	[Export] public float RotationSpeed = 1;
	[Export] public float BoostPower = 1;
    public override void _Process(double delta)
	{
		if(Input.IsActionPressed("rotate_left")){
			Rotation -= (float)delta * RotationSpeed;
		}

		if(Input.IsActionPressed("rotate_right")){
			Rotation += (float)delta * RotationSpeed;
		}

		if(Input.IsActionPressed("boost")){
			Velocity += GlobalTransform.BasisXform(Vector2.Up) * BoostPower * (float)delta; 
		}
	}
}
