using Godot;
using System;

public partial class PlayerController : ShipComponent{
	public static Ship playerShip;

    public override void _EnterTree()
    {
		base._EnterTree();
		playerShip = Ship;
    }
    public override void _Process(double delta)
	{
		Ship.ControlRotating = 0;
		if(Input.IsActionPressed("rotate_left")){
			Ship.ControlRotating = -1;
		}

		if(Input.IsActionPressed("rotate_right")){
			Ship.ControlRotating = 1;
		}

		if(Input.IsActionPressed("boost")){
			Ship.ControlBoosting = true;
		}else{
			Ship.ControlBoosting = false;
		}
	}
}
