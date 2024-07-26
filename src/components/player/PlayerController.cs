using Godot;
using System;

public partial class PlayerController : Node
{
	public static Ship playerShip;
	private Ship ship;

    public override void _Ready()
    {
        ship = GetParent<Ship>();
		playerShip = ship;
    }
    public override void _Process(double delta)
	{
			ship.ControlRotating = 0;
		if(Input.IsActionPressed("rotate_left")){
			ship.ControlRotating = -1;
		}

		if(Input.IsActionPressed("rotate_right")){
			ship.ControlRotating = 1;
		}

		if(Input.IsActionPressed("boost")){
			ship.ControlBoosting = true;
		}else{
			ship.ControlBoosting = false;
		}
	}
}
