using Godot;
using System;
using System.Diagnostics;

public partial class RotatorAttachment : Attachment<RotatorAttachment,RotationHardpoint>
{
    [Export] private StatType rotationSpeedStatType;
    public RotationHardpoint Hardpoint;
    private Stat rotationSpeedStat;

    public override void _EnterTree()
    {
        DebugTools.IsParentType(typeof(RotationHardpoint), this);
        Hardpoint = GetParent<RotationHardpoint>();
        Hardpoint.Gyroscope = this;
        rotationSpeedStat = Hardpoint.Ship.Character.StatBlock.GetStat(rotationSpeedStatType);
    }

    public override void _Process(double delta)
    {
        Hardpoint.Ship.Rotation += (float)delta *rotationSpeedStat.GetValue() * Hardpoint.Ship.ControlRotating;
    }
}
