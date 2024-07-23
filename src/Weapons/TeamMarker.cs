using Godot;
using System;

public partial class TeamMarker : Node
{
	[Signal] public delegate void TeamChangedEventHandler(bool newTeam);
	private bool _playerTeam;
	[Export] public bool PlayerTeam{ 
		get{
			return _playerTeam;
		} 
		set{
			EmitSignal(SignalName.TeamChanged, value);
			_playerTeam = value;
		}
	}
}
