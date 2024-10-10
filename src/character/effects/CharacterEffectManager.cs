using Godot;
using System;
using System.Collections.Generic;

public partial class CharacterEffectManager
{
	private Character character;
	private List<CharacterEffect> characterEffects = new List<CharacterEffect>();

	public CharacterEffectManager(Character character){
		this.character = character;
	}

	public void AddEffect(CharacterEffect characterEffect){
		if(characterEffects.Contains(characterEffect)){
			return;
		}

		characterEffects.Add(characterEffect);
		characterEffect.Start();
	}

	public void RemoveEffect(CharacterEffect characterEffect){
		if(!characterEffects.Contains(characterEffect)){
			return;
		}

		characterEffect.Cleanup();
		characterEffects.Remove(characterEffect);
	}

    internal IReadOnlyCollection<CharacterEffect> GetEffects()
    {
        return characterEffects;
    }

}
