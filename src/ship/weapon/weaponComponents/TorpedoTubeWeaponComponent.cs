using Godot;
using System;

[GlobalClass]
public partial class TorpedoTubeWeaponComponent : BarrelWeaponComponent
{
	private TorpedoSpawner torpedoSpawner;
    public override void _Ready()
    {
		base._Ready();
		torpedoSpawner = Spawner as TorpedoSpawner;
        Weapon.Character.CharacterEventHandler.PostRegister<TargetChangedEvent>(OnTargetChanged);
    }

	private void OnTargetChanged(CharacterEvent characterEvent){
		TargetChangedEvent e = characterEvent as TargetChangedEvent;
		torpedoSpawner.Target = e.Target;
	}
}
