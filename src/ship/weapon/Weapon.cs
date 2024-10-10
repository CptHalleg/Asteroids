using Godot;
using System;
using System.Diagnostics;

[GlobalClass]
public partial class Weapon : Attachment<Weapon, WeaponHardpoint>
{
	[Export] public string DisplayName;
	public TeamMarker TeamMarker{get; private set;}
	public Character Character{get; private set;}

    public override void _EnterTree()
	{
		base._EnterTree();


		DebugTools.IsChildType(typeof(TeamMarker),0,this);
		TeamMarker = GetChild<TeamMarker>(0);
		TeamMarker.Team = Hardpoint.Ship.TeamMarker.Team;

		DebugTools.IsChildType(typeof(Character),1,this);
		Character = GetChild<Character>(1);
	}
} 
