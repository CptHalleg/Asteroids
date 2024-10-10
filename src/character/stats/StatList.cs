using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[GlobalClass]
public partial class StatList : Resource
{
	[Export] private Array<StatType> statTypes = new Array<StatType>();

	public IReadOnlyCollection<StatType> GetStatTypes(){
		return statTypes;
	}
}
