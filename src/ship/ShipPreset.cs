using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class ShipPreset : Resource
{
	[Export] public PackedScene ShipScene;
	[Export] private Array<PackedScene> weapons;
	[Export] private Array<PackedScene> drives;
	[Export] private Array<PackedScene> rotators;

	public Ship InstanciateShip(){
        Ship ship = ShipScene.Instantiate<Ship>();
		int currentHardpointIndex = 0;
		foreach(PackedScene weaponScene in weapons){
			Weapon weapon = weaponScene.Instantiate<Weapon>();
			ship.WeaponHardpoints[currentHardpointIndex].AddChild(weapon);
		}

		currentHardpointIndex = 0;
		foreach(PackedScene weaponScene in weapons){
			DriveAttachment drive = weaponScene.Instantiate<DriveAttachment>();
			ship.DriveHardpoints[currentHardpointIndex].AddChild(drive);
		}

		currentHardpointIndex = 0;
		foreach(PackedScene weaponScene in weapons){
			RotatorAttachment rotator = weaponScene.Instantiate<RotatorAttachment>();
			ship.WeaponHardpoints[currentHardpointIndex].AddChild(rotator);
		}
		return ship;
	}
}
