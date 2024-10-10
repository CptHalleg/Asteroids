using Godot;
using System;
using System.Diagnostics;

public partial class HealthManager : Node
{
    [Export] private ResourceStatType healthStatType;
    private Character character;
	public override void _Ready()
	{
		DebugTools.IsParentType(typeof(Character), this);
		character = GetParent<Character>();
		character.CharacterEventHandler.PostRegister<TakeDamageEvent>(OnTakenDamage);
		DebugTools.IsSet(healthStatType, this);
		CappedStat health = character.StatBlock.GetStat<CappedStat>(healthStatType);
		health.ValueChanged += OnHealthChanged;
		health.SetValue(health.max.GetValue());
	}

    private void DoDeath()
    {
        GameoverUI.Instance.Visible = true;
		character.GetParent().QueueFree();
    }

    private void OnHealthChanged(float newValue)
    {
        if(newValue <= 0){
			character.CharacterEventHandler.CauseEvent(new DeathEvent(){Execute = DoDeath});
		}
    }

    private void OnTakenDamage(CharacterEvent e)
	{
		character.StatBlock.GetStat<ResourceStat>(healthStatType).ModifyValue(-((TakeDamageEvent)e).Damage);
	}
}
