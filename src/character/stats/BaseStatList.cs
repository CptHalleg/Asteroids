using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class BaseStatList : Resource
{
	[Export] public StatList StatList{get; private set;}
	[Export] private Array<BaseStatValue> baseStatValues;

	public IReadOnlyCollection<BaseStatValue> GetBaseStatValues(){
		return baseStatValues;
	}
}
