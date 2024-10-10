using Godot;
using System;

public partial class ShipComponent : Node2D
{
	public Ship Ship{get; private set;}

    public override void _EnterTree()
    {
        DebugTools.IsParentType(typeof(Ship), this);
		Ship = GetParent<Ship>();
    }
}
