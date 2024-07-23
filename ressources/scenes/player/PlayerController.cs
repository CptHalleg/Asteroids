using Godot;
using System;

public partial class PlayerController : Node
{
	private Ship ship;
	[Export] public float RotationSpeed = 1;

    public override void _Ready()
    {
        ship = GetParent<Ship>();
    }
    public override void _Process(double delta)
	{
		if(Input.IsActionPressed("rotate_left")){
			ship.Rotation -= (float)delta * RotationSpeed;
		}

		if(Input.IsActionPressed("rotate_right")){
			ship.Rotation += (float)delta * RotationSpeed;
		}

		if(Input.IsActionPressed("boost")){
			ship.ControlBoosting = true;
		}else{
			ship.ControlBoosting = false;
		}
	}
}
