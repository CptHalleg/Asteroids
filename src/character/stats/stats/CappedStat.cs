using System;

public partial class CappedStat : ResourceStat
{
	public Stat max{get; private set;}

	public CappedStat(CappedStatType statType, StatBlock statistics, Stat max) : base(statType, statistics)
	{
		this.max = max;
		max.ValueChanged += OnMaxValueChanged;
	}

	private void OnMaxValueChanged(float newMax)
	{
		if(value > newMax){
			value = newMax;
		}
	}

	public override void SetValue(float value)
	{
		float maxValue = max.GetValue();
		if(value > maxValue){
			value = maxValue;
		}
		base.SetValue(value);
	}
}
