using Godot;
using System;
using System.Diagnostics;

public partial class Ship : SimpleRigidbody2D
{
	[Export] public float MaxSpeed = 0;
	public bool Doomed{get; private set;}
	private Timer doomTimer;
	public bool ControlBoosting;
	public int ControlRotating;

	public void Doom(){
		if(Doomed){
			return;
		}
		Doomed = true;
		doomTimer.Start();
	}

    public override void _Ready()
    {
        doomTimer = new Timer();
		AddChild(doomTimer);
		doomTimer.WaitTime = 10;
		doomTimer.OneShot = true;
		doomTimer.Timeout += DoomTimeout;
    }

    private void DoomTimeout()
    {
       QueueFree();
    }

	public void Damaged(DamageDealer damageDealer){
		Doom();
	}

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
		if(MaxSpeed > 0 && Velocity.Length() > MaxSpeed){
			Velocity = Velocity.Normalized() * MaxSpeed;
		}
    }

    public bool IsRotationDirection(bool PositiveRotationDirection){
		bool fireForRoatation = false;
		if(!PositiveRotationDirection && ControlRotating < 0){
			fireForRoatation = true;
		}else if(PositiveRotationDirection && ControlRotating > 0){
			fireForRoatation = true;
		}
		return fireForRoatation;
	}
}
