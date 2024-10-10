using Godot;
using System;

public partial class StatusUI : Control
{
	[Export] private HealthBarUI healthBar;
	[Export] private EffectDisplayUI effectDisplay;
    public override void _Ready()
    {
        healthBar.Ship = PlayerController.playerShip;
        effectDisplay.Character = PlayerController.playerShip.Character;
    }
}
