using Godot;
using System;
using System.Diagnostics;

public partial class DriveAttachment : Attachment<DriveAttachment, DriveHardpoint>
{
	[Signal] public delegate void ActiveChangedEventHandler(bool newActive);
	[Export] private StatType boostSpeedStatType;
	public DriveHardpoint Hardpoint {get; private set;}
	public bool Active;
	private Stat boostSpeedStat;

	public override void _EnterTree()
	{
		DebugTools.IsParentType(typeof(DriveHardpoint),this);
		Hardpoint = GetParent<DriveHardpoint>();
		Hardpoint.Drive = this;
		boostSpeedStat = Hardpoint.Ship.Character.StatBlock.GetStat(boostSpeedStatType);
	}

    public override void _Process(double delta)
    {
		bool newActive = false;
		if(Hardpoint.Ship.ControlBoosting){
			Hardpoint.Ship.Velocity += Hardpoint.Ship.GlobalTransform.BasisXform(Vector2.Up) * boostSpeedStat.GetValue() * (float)delta;
			newActive = true;
		}
		if(Active != newActive){
			EmitSignal(SignalName.ActiveChanged, newActive);
		}
		Active = newActive;
    }
}
