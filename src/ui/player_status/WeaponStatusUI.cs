using Godot;
using System;
using System.Diagnostics;

public partial class WeaponStatusUI : Control
{
	[Export] private EffectDisplayUI effectDisplayUI;
	[Export] private Label nameDisplay;

	public Weapon Weapon { get; private set; }

	public void Init(Weapon weapon)
	{
		Weapon = weapon;
		Debug.WriteLine(nameDisplay == null);
		effectDisplayUI.Character = Weapon.Character;
		nameDisplay.Text = Weapon.DisplayName + " (" + Weapon.Hardpoint.DisplayName + ")";
	}
	public override void _Ready()
	{
		DebugTools.IsSet(effectDisplayUI, this);
		DebugTools.IsSet(nameDisplay, this);
	}
}
