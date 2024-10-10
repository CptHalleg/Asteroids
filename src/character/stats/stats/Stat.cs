using System;

public abstract class Stat
{
	public abstract float GetValue();
	public event Action<float> ValueChanged;
	protected void EmitValueChanged(float newValue){
		ValueChanged?.Invoke(newValue);
	}
	public StatBlock Statistics{get; private set;}
	public StatType StatType{get; private set;}
	public Stat(StatType statType, StatBlock statistics){
		StatType = statType;
		Statistics = statistics;
	}
}
