using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public partial class Ship : SimpleRigidbody2D
{
	[Export] public float MaxSpeed = 0;
	public bool ControlBoosting;
	public int ControlRotating;
	private List<WeaponHardpoint> weaponHardpoints = new List<WeaponHardpoint>();
	private List<DriveHardpoint> driveHardpoints = new List<DriveHardpoint>();
	private List<RotationHardpoint> rotationHardpoints = new List<RotationHardpoint>();
	public TeamMarker TeamMarker{get; private set;}
	public Character Character{get; private set;}

    public override void _EnterTree()
    {
        DebugTools.IsChildType(typeof(TeamMarker), 0, this);
		TeamMarker = GetChild<TeamMarker>(0);
        DebugTools.IsChildType(typeof(Character), 1, this);
		Character = GetChild<Character>(1);
		InitHardPoints();
    }

    public void Damaged(DamageDealer damageDealer){
		QueueFree();
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

    internal void InitHardPoints()
    {
		foreach(Node node in GetChildren()){
			if(node is WeaponHardpoint weaponHardpoint){
				weaponHardpoints.Add(weaponHardpoint);
			}
		}

		foreach(Node node in GetChildren()){
			if(node is DriveHardpoint driveHardpoint){
				driveHardpoints.Add(driveHardpoint);
			}
		}

		foreach(Node node in GetChildren()){
			if(node is RotationHardpoint rotationHardpoint){
				rotationHardpoints.Add(rotationHardpoint);
			}
		}
    }

	public IReadOnlyCollection<WeaponHardpoint> GetHardpoints(){
		return weaponHardpoints;
	}
}
