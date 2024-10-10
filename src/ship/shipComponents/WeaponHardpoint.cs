using Godot;
using System;

[GlobalClass]
public partial class WeaponHardpoint : HardpointShipComponent<Weapon, WeaponHardpoint>
{
	[Export] public string DisplayName;
}
