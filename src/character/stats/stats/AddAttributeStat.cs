using System;

public class AddAttributeStat : AttributeStat
{
    public AddAttributeStat(AddAttributeStatType statType, StatBlock statistics) : base(statType, statistics)
    {
    }

    protected override float CalculateResult(float accumulated)
    {
        return accumulated;
    }
}
