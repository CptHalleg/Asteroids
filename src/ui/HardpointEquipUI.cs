using Godot;
using System;

public partial class HardpointEquipUI : Node
{
	[Export] private Label nameLabel;
	[Export] private Button removeButton;
	[Export] private Button addButton;
	[Export] private PackedScene weaponDetailsScene;
	public WeaponHardpoint Hardpoint { get; internal set; }
	private WeaponDetailsUI weaponDetailsUI;

    public override void _Ready()
	{
		nameLabel.Text = Hardpoint.DisplayName;
		ChangeWeapon(Hardpoint.Attachment);

		removeButton.ButtonUp += OnRemove;
		addButton.ButtonUp += OnAdd;
	}

    private void OnAdd()
    {

    }


    private void OnRemove()
    {
		Hardpoint.RemoveChild(Hardpoint.Attachment);
		Hardpoint.Attachment.QueueFree();
		ChangeWeapon(null);
	}

    private void ChangeWeapon(Weapon weapon){
		if(weaponDetailsUI != null){
			RemoveChild(weaponDetailsUI);
			weaponDetailsUI.QueueFree();
			weaponDetailsUI = null;
		}

		if(weapon != null){
			weaponDetailsUI = weaponDetailsScene.Instantiate<WeaponDetailsUI>();
			weaponDetailsUI.Weapon = weapon;
			AddChild(weaponDetailsUI);
			
			removeButton.Visible = true;
			addButton.Visible = false;
		}else{
			removeButton.Visible = false;
			addButton.Visible = true;
		}
	}
}
