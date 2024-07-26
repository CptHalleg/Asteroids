using Godot;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;

public partial class ManouveringThruster : Node2D
{
	[Export] public bool PositiveRotationDirection;
	[Signal] public delegate void StateChangedEventHandler(bool newState);
	[Signal] public delegate void ActivatedEventHandler();
	[Signal] public delegate void DeactivatedEventHandler();
	public bool Active;
	private bool prevOppositeRotation;
	private bool counterThrusting;
	private Ship ship;
	private Timer timer;

    public override void _Ready()
    {
        ship = GetParent<Ship>();
		timer = new Timer();
		AddChild(timer);
		timer.Timeout += CounterThrustingTimeout;
		timer.WaitTime = 0.2f;
		timer.OneShot = true;
    }

    private void CounterThrustingTimeout()
    {
		counterThrusting = false;
    }


    public override void _Process(double delta)
    {
		bool fireForRoatation = ship.IsRotationDirection(PositiveRotationDirection);

		if(prevOppositeRotation && ship.ControlRotating == 0){
			counterThrusting = true;
			timer.Start();
		}

		if(fireForRoatation){
			counterThrusting = false;
			timer.Stop();
		}

		fireForRoatation = fireForRoatation || counterThrusting;
		
		if(Active != fireForRoatation){
			EmitSignal(SignalName.StateChanged, fireForRoatation);
			if(fireForRoatation){
				EmitSignal(SignalName.Activated);
			}else{
				EmitSignal(SignalName.Deactivated);	
			}
		}

		Active = fireForRoatation;

		prevOppositeRotation = ship.IsRotationDirection(!PositiveRotationDirection);
    }
}
