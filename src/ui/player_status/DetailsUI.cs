using Godot;
using System;
using System.Diagnostics;

public partial class DetailsUI : Control
{
	[Export] private StatDisplayUI shipStatDisplay;
	[Export] private Control weaponDetailsRoot;
	[Export] private PackedScene weaponDetailsScene;

	public override void _Ready()
	{
		DebugTools.IsSet(shipStatDisplay, this);
		shipStatDisplay.Character = PlayerController.playerShip.Character;

		foreach(WeaponHardpoint weaponHardpoint in PlayerController.playerShip.GetHardpoints()){
			WeaponDetailsUi c = weaponDetailsScene.Instantiate<WeaponDetailsUi>();
			c.Weapon = weaponHardpoint.Attachment;
			weaponDetailsRoot.AddChild(c);
		}
		Visible = false;
	}


    public override void _Input(InputEvent @event)
    {
        if(@event.IsActionPressed("display_stats")){
			Visible = !Visible;
		}
    }
}
