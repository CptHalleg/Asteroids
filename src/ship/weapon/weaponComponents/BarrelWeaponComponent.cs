using Godot;
using System;

[GlobalClass]
public partial class BarrelWeaponComponent : WeaponComponent
{
	[Export] public Spawner Spawner { get; private set; }

	public override void _Ready()
	{
		base._Ready();
		Weapon.Character.CharacterEventHandler.PostRegister<FireWeaponEvent>(OnFireWeapon);
	}

	private void OnFireWeapon(CharacterEvent e)
	{
		FireWeaponEvent f = e as FireWeaponEvent;
		if (f.Weapon == Weapon)
		{
			Spawner.Spawn();
		}
	}
}
