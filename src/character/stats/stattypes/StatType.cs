using Godot;
using System;

public partial class StatType : Resource {
	[Export] public string DisplayName{get; private set;}
	[Export] public string Units{get; private set;}

	public virtual Stat NewStat(StatBlock statistics){
		throw new NotImplementedException();
	}
}
