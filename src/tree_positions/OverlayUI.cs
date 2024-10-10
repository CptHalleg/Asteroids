using Godot;
using System;

public partial class OverlayUI : Node
{
	public static OverlayUI Instance;

    public override void _EnterTree()
    {
        Instance = this;
    }
}
