using Godot;
using System;

public partial class StatType : Resource {
	[Export] public string Name{get; private set;}
	public virtual Stat NewStat(StatBlock statistics){
		throw new NotImplementedException();
	}
}
