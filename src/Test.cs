using Godot;
using System;

public partial class Test : RichTextLabel
{
	public override void _Process(double delta)
	{
		string str = "player ship " + TargetList.GetTargets(Team.Player, TargetType.Ship).Count + "\n";
		str += "enemy ship " + TargetList.GetTargets(Team.Enemy, TargetType.Ship).Count + "\n";
		str += "player missle " + TargetList.GetTargets(Team.Player, TargetType.Missle).Count + "\n";
		str += "enemy missle " + TargetList.GetTargets(Team.Enemy, TargetType.Missle).Count + "\n";
		Text = str;
	}
}
