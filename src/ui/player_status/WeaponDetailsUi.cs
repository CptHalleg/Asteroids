using Godot;
using System;

public partial class WeaponDetailsUi : Node
{
	[Export] private Label nameDusplay;
	[Export] private StatDisplayUI statDisplay;

	public Weapon Weapon;

    public override void _Ready()
    {
        nameDusplay.Text = Weapon.Name;
		statDisplay.Character = Weapon.Character;
    }
}
