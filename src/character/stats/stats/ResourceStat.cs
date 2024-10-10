using System;
using System.Diagnostics;

public class ResourceStat : Stat
{
	protected float value;
    public ResourceStat(ResourceStatType statType, StatBlock statistics) : base(statType, statistics)
    {
    }

    public override float GetValue()
    {
        return value;
    }

    public virtual void SetValue(float newValue){
        if(this.value != newValue){
            EmitValueChanged(newValue);
        }
        this.value = newValue;
    }

    public virtual void ModifyValue(float newValue)
    {
        SetValue(this.value + newValue);
    }
}
