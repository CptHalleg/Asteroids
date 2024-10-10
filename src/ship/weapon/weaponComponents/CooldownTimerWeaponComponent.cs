using Godot;
using Godot.NativeInterop;
using System;
using System.Diagnostics;
using System.Dynamic;

[GlobalClass]
public partial class CooldownTimerWeaponComponent : WeaponComponent
{
	[Export] public StatType FireRateStatType { get; private set; }
	[Export] public bool AutoUse = false;
	public Stat FireRate { get; private set; }
	public bool IsReady { get; private set; } = true;

    public override void _Ready()
    {
        base._Ready();

		DebugTools.IsSet(FireRateStatType, this);
		FireRate = Weapon.Character.StatBlock.GetStat(FireRateStatType);
    }

    public override void _Process(double delta)
	{
		if (IsReady)
		{
			Weapon.Character.CharacterEventHandler.CauseEvent(new FireWeaponEvent(Weapon) { Execute = OnFireWeapon });
		}
	}

	private void OnFireWeapon()
	{
		IsReady = false;
		TimerManager.SetTimer(1/FireRate.GetValue(), OnTimeout);
	}

	private void OnTimeout()
	{
		IsReady = true;
	}
}
