using Godot;
using System;

public partial class PlayerShipStatusUI : Control
{
	[Export] private PackedScene MagazinLabelScene;
	[Export] private Control MagazinLabelParent;
	public static PlayerShipStatusUI Instance {get; private set;}
	// Called when the node enters the scene tree for the first time.
	public override void _EnterTree()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    internal Label AddMagazinLabel()
    {
        Label label = MagazinLabelScene.Instantiate<Label>();
		MagazinLabelParent.AddChild(label);
		return label;
    }

}
