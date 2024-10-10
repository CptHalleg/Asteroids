using Godot;
using System;

public partial class StatDisplayUI : RichTextLabel
{
	public Character Character;

    public override void _Ready()
    {
        Character = PlayerController.playerShip.Character;
    }

    public override void _Process(double delta)
    {
        string str = "";

		foreach(var pair in Character.StatBlock.GetValues()){
			str += pair.Key.Name + ": " + pair.Value.GetValue() + "\n";
		}

		Text = str;
    }
}
