using Godot;
using System;

public partial class Drive : Node2D
{
	[Export] public float BoostPower = 200;
	[Signal] public delegate void StateChangedEventHandler(bool newState);
	[Signal] public delegate void ActivatedEventHandler();
	[Signal] public delegate void DeactivatedEventHandler();
	public bool Active;
	private Ship ship;

	public override void _Ready()
	{
		ship = GetParent<Ship>();
	}

    public override void _Process(double delta)
    {
		bool newActive = false;
		if(ship.ControlBoosting){
			ship.Velocity += ship.GlobalTransform.BasisXform(Vector2.Up) * BoostPower * (float)delta;
			newActive = true;
		}
		

		if(Active != newActive){
			EmitSignal(SignalName.StateChanged, newActive);
			if(newActive){
				EmitSignal(SignalName.Activated);
			}else{
				EmitSignal(SignalName.Deactivated);	
			}
		}
		Active = newActive;
    }
}
