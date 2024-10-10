using Godot;
using System;

[GlobalClass]
public partial class DriveHardpoint : HardpointShipComponent<DriveAttachment, DriveHardpoint>
{
	[Export] public string DisplayName;
	public DriveAttachment Drive;
}
