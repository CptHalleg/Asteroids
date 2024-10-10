using Godot;
using System;
using System.Diagnostics;
using System.Dynamic;

[GlobalClass]
public partial class MagazinWeaponComponent : WeaponComponent
{
	[Export] public StatType maxCountStatType { get; private set; }
	[Export] public StatType currentCountStatType { get; private set; }
	[Export] public StatType reloadTimeStatType { get; private set; }
	[Export] public bool Reloading { get; private set; } = false;
	[Export] public bool AutoReload = false;
	public Stat MaxCountStat { get; private set; }
	public ResourceStat CurrentCountStat { get; private set; }
	public Stat ReloadTimeStat { get; private set; }

	public override void _Ready()
	{
		base._Ready();
		Character character = Weapon.Character;

		DebugTools.IsSet(maxCountStatType,this);
		DebugTools.IsSet(currentCountStatType,this);
		DebugTools.IsSet(reloadTimeStatType,this);
		
		MaxCountStat = character.StatBlock.GetStat(maxCountStatType);
		CurrentCountStat = character.StatBlock.GetStat<ResourceStat>(currentCountStatType);
		ReloadTimeStat = character.StatBlock.GetStat(reloadTimeStatType);
		CurrentCountStat.SetValue(MaxCountStat.GetValue());

		character.CharacterEventHandler.PreRegister<FireWeaponEvent>(OnFireWeaponPre);
		character.CharacterEventHandler.PostRegister<FireWeaponEvent>(OnFireWeaponExecute);
		character.CharacterEventHandler.PostRegister<ReloadFinishEvent>(OnFinishReload);
	}

	private void OnFireWeaponExecute(CharacterEvent e)
	{
		Weapon.Character.CharacterEventHandler.CauseEvent(new AmmoConsumedEvent(){Execute = DoAmmoConsumed});
		if (CurrentCountStat.GetValue() <= 0 && AutoReload && !Reloading)
		{
			Reloading = true;
			Weapon.Character.CharacterEventHandler.CauseEvent(new ReloadStartEvent(){Execute = DoStartReload});
		}
	}


	private void OnFireWeaponPre(CharacterEvent characterEvent)
	{
		if (Reloading || CurrentCountStat.GetValue() <= 0)
		{
			characterEvent.Cancel();
		}
	}

	private void DoAmmoConsumed()
	{
		CurrentCountStat.ModifyValue(-1);
	}

	private void DoStartReload()
	{
		Reloading = true;
		Weapon.Character.CharacterEffectManager.AddEffect(new ReloadEffect(Weapon.Character, ReloadTimeStat.GetValue(), MaxCountStat.GetValue()));
	}

	private void OnFinishReload(CharacterEvent e)
	{
		Reloading = false;
		CurrentCountStat.SetValue(MaxCountStat.GetValue());
		Weapon.Character.CharacterEventHandler.CauseEvent(new ReloadEvent());
		return;
	}
}
