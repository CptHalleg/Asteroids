using Godot;
using System;

public partial class PlayerShipStatusUI : Control
{
	public static PlayerShipStatusUI Instance {get; private set;}
	public override void _EnterTree()
	{
		Instance = this;
	}
}
