using Godot;
using System;
using System.ComponentModel.Design;

public partial class PostDamageInvincibility : Node
{
    [Export] private StatType invinciblityStat;
	private Character character;
    private InvincibilityEffect invincibility;

    public override void _Ready()
    {
        DebugTools.IsParentType(typeof(Character),this);
        character = GetParent<Character>();
        character.CharacterEventHandler.PreRegister<TakeDamageEvent>(OnTakeDamage);
    }

    private void OnTakeDamage(CharacterEvent e)
    {
        if(invincibility != null && invincibility.Active){
            return;
        }
        invincibility = new InvincibilityEffect(character, invinciblityStat);
        character.CharacterEffectManager.AddEffect(invincibility);
    }

}
