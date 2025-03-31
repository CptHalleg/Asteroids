using Godot;
using System;
using System.Diagnostics;

public partial class WeaponsListUI : HBoxContainer
{
    [Export] public PackedScene WeaponStatusUIScene { get; private set; }
	public static WeaponsListUI Instance{get; private set;}

    public override void _Ready()
    {
        foreach(WeaponHardpoint currentHardpoint in PlayerController.playerShip.WeaponHardpoints){
            Weapon weapon = currentHardpoint.Attachment;
            WeaponStatusUI weaponStatusUI = WeaponStatusUIScene.Instantiate<WeaponStatusUI>();
            weaponStatusUI.Init(weapon);
            AddChild(weaponStatusUI);
        }
    }
}
