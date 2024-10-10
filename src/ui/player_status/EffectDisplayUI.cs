using Godot;
using System;

[GlobalClass]
public partial class EffectDisplayUI : RichTextLabel
{
	public Character Character;

    public override void _Process(double delta)
    {
        UpdateStatDisplay();
    }

	private void UpdateStatDisplay(){
		Text = "";
		if(Visible){
			foreach(CharacterEffect currentCharacterEffect in Character.CharacterEffectManager.GetEffects()){
				Text += currentCharacterEffect.GetDiscription() + "\n";
			}
		}
	}
}
