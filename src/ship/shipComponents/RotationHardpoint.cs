using Godot;
using System;

[GlobalClass]
public partial class RotationHardpoint : HardpointShipComponent<RotatorAttachment, RotationHardpoint>
{
	[Export] public string DisplayName;
	public RotatorAttachment Gyroscope;
}
