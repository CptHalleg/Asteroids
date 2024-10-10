using Godot;
using System;

public partial class WeaponComponent : Node2D
{
	public Weapon Weapon { get; private set; }

	public override void _Ready()
	{
		DebugTools.IsParentType(typeof(Weapon), this);
		Weapon = GetParent<Weapon>();
	}
}
