using Godot;
using System;

[GlobalClass]
public partial class Targetable : Node2D
{
	[Export] public TeamMarker TeamMarker;
	[Export] public TargetType Type;
    public Team Team{get{return TeamMarker.Team;}}

    public override void _Ready()
	{
		DebugTools.IsSet(TeamMarker, this);
		TargetList.AddTargetable(this);
	}
}
