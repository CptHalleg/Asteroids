using Godot;
using System;

[GlobalClass]
public partial class TeamMarker : Node
{
	[Signal] public delegate void TeamChangedEventHandler(Team newTeam);
	private Team _team;
	[Export] public Team Team{ 
		get{
			return _team;
		} 
		set{
			EmitSignal(SignalName.TeamChanged, (int) value);
			_team = value;
		}
	}
}
