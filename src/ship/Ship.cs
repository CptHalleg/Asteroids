using Godot;
using System;
using System.Diagnostics;

public partial class Ship : SimpleRigidbody2D
{
	[Export] public float MaxSpeed = 0;
	public bool ControlBoosting;
	public int ControlRotating;

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
