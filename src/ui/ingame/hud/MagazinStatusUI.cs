using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class MagazinStatusUI : HFlowContainer
{
	[Export] private PackedScene bulletScene;
	[Export] private StatType currentBulletCountStatType;
	[Export] private WeaponStatusUI weaponStatusUI;

    public async override void _Ready()
    {
		DebugTools.IsSet(bulletScene, this);
		DebugTools.IsParentType(typeof(WeaponStatusUI),this);
		weaponStatusUI.Weapon.Character.CharacterEventHandler.PostRegister<AmmoConsumedEvent>(OnAmmoConsumed);
		weaponStatusUI.Weapon.Character.CharacterEventHandler.PostRegister<ReloadEvent>(OnReload);
		
        await ToSignal( GetTree(),SceneTree.SignalName.ProcessFrame); 
		OnReload(null);
    }

	private void OnReload(CharacterEvent e){
		int v = (int)weaponStatusUI.Weapon.Character.StatBlock.GetValue(currentBulletCountStatType);
		for(int i = 0; i < v; i++){
			AddChild(bulletScene.Instantiate());
		}
	}

    private void OnAmmoConsumed(CharacterEvent e)
    {
		if(GetChildCount() <= 0){
			return;
		}
		GetChild(GetChildCount()-1).QueueFree();
    }

}
