using Godot;
using System;
using System.Collections.Generic;

public abstract class AttributeStat : Stat
{
    protected List<StatModifier> modifiers = new List<StatModifier>();

    public AttributeStat(AttributeStatType statType, StatBlock statistics) : base(statType, statistics)
    {
    }

    public override float GetValue()
    {
        float accumulated = 0;
        foreach (StatModifier currentModifier in modifiers)
        {
            accumulated += currentModifier.GetValue();
        }
        return CalculateResult(accumulated);
    }

    protected abstract float CalculateResult(float accumulated);

    public void AddModifier(StatModifier statModifier)
    {
        modifiers.Add(statModifier);
    }

}
