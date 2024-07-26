using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public static partial class TargetList
{
	public static Dictionary<Team,Dictionary<Type,List<TeamMarker>>> targets;

	

	public enum Team{
		Player,Enemy, None
	}

	public enum Type{
		Ship, Missle, Bullet
	}
	public static Team Opposition(this Team team){
		switch(team){
			case Team.Player: return Team.Enemy;
			case Team.Enemy: return Team.Player;
		}
		return team;
	}
}