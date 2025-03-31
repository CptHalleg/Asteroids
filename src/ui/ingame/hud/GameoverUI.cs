using Godot;
using System;

public partial class GameoverUI : Label
{
	public static GameoverUI Instance{get; private set;}
	public override void _EnterTree()
	{
		Instance = this;
		Visible =false;
	}
}
