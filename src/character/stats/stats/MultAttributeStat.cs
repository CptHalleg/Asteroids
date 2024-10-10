using System;
using System.Diagnostics;

public partial class MultAttributeStat : AttributeStat
{
    protected Stat baseStat;

    public MultAttributeStat(MultiAttributeStatType statType, StatBlock statistics, Stat baseStat) : base(statType, statistics)
    {
        this.baseStat = baseStat;
    }

    protected override float CalculateResult(float accumulated)
    {
        return baseStat.GetValue() * 1 + accumulated;
    }

    protected Stat GetBaseValue()
    {
        return baseStat;
    }
}
