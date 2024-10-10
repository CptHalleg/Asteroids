using Godot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public static class TargetList
{
	private static Dictionary<Team,Dictionary<TargetType,HashSet<Targetable>>> targets = new Dictionary<Team,Dictionary<TargetType,HashSet<Targetable>>>();
    public static IReadOnlyCollection<Targetable> GetTargets(Team team, TargetType type)
    {
		if(!targets.ContainsKey(team)){
			return new HashSet<Targetable>();
		}

		if(!targets[team].ContainsKey(type)){
			return new HashSet<Targetable>();
		}
        return targets[team][type];
    }

	public static bool AddTargetable(Targetable targetable)
	{
		if(!targets.ContainsKey(targetable.Team)){
			targets.Add(targetable.Team, new Dictionary<TargetType, HashSet<Targetable>>());
		}

		if(!targets[targetable.Team].ContainsKey(targetable.Type)){
			targets[targetable.Team].Add(targetable.Type, new HashSet<Targetable>());
		}

		return targets[targetable.Team][targetable.Type].Add(targetable);
	}

	public static bool RemoveTargetable(Targetable targetable)
	{
		if(!targets.ContainsKey(targetable.Team)){
			return false;
		}
		
		if(!targets[targetable.Team].ContainsKey(targetable.Type)){
			return false;
		}
		return targets[targetable.Team][targetable.Type].Remove(targetable);
	}

	public static Team Opposition(this Team team)
	{
		switch(team){
			case Team.Player: return Team.Enemy;
			case Team.Enemy: return Team.Player;
		}
		return team;
	}
}

public enum Team{
	None,Player,Enemy
}

public enum TargetType{
	Ship, Missle, Bullet
}
