using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class Character : Node
{
	public CharacterEffectManager CharacterEffectManager;
	public CharacterEventHandler CharacterEventHandler;
	public StatBlock StatBlock{get; private set;}
	[Export] private BaseStatList baseStatList;

	public override void _EnterTree()
	{
		Dictionary<StatType, float> baseValues = new Dictionary<StatType, float>();
		
		foreach(BaseStatValue baseStatValue in baseStatList.GetBaseStatValues()){
			baseValues[baseStatValue.AttributeStatType] = baseStatValue.Value;
		}

		StatBlock = new StatBlock();
		foreach(StatType statType in baseStatList.StatList.GetStatTypes()){
			StatBlock.InitStatType(statType);
			if(baseValues.ContainsKey(statType)){
				StatBlock.GetStat<AttributeStat>(statType).AddModifier(new StatModifier(baseValues[statType]));
			}
		}
		CharacterEffectManager = new CharacterEffectManager(this);
		CharacterEventHandler = new CharacterEventHandler(this);
	}

	public override void _Ready()
	{
	}

}
