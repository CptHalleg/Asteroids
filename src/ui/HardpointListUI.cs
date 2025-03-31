using Godot;
using System.Collections.Generic;

public partial class HardpointListUI : Control
{
	[Export] private PackedScene hardpoitEquipScene;
	[Export] private PackedScene weaponEquipScene;
	[Export] private Container hardpointListRoot;
	[Export] private Container attachmentOptionsListRoot;
	private List<HardpointEquipUI> hardpointEquipUIs = new List<HardpointEquipUI>();
	private List<HardpointEquipUI> attachmentOptions;

    public override void _Ready()
    {
        ChangeHull(PlayerController.playerShip);
    }

	public void OpenList(){
		for(int i = 0; i < 5; i++){

			//attachmentOptionsListRoot.AddChild();
		}

		hardpointListRoot.Visible = false;
		attachmentOptionsListRoot.Visible = true;
	}

    public void ChangeHull(Ship ship){
		foreach(var hardpointUI in hardpointEquipUIs){
			hardpointListRoot.RemoveChild(hardpointUI);
			hardpointUI.QueueFree();
		}

		foreach(var hardpoint in ship.WeaponHardpoints){
			HardpointEquipUI hardpointUI = hardpoitEquipScene.Instantiate<HardpointEquipUI>();
			hardpointUI.Hardpoint = hardpoint;
			hardpointListRoot.AddChild(hardpointUI);
		}
	}
}
