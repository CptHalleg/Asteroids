using Godot;
using System;

[GlobalClass]
public partial class CharacterDamagable : Node
{
	private DamagableArea damagableArea;
    [Export] private Character character;

    public override void _Ready()
    {
		DebugTools.IsParentType(typeof(DamagableArea), this);
        damagableArea = GetParent<DamagableArea>();
        DebugTools.IsSet(character, this);
        damagableArea.Damaged += OnDamaged;
    }

    private void OnDamaged(DamageDealer damageDealer)
    {
        character.CharacterEventHandler.CauseEvent(new TakeDamageEvent(1));
    }

}
