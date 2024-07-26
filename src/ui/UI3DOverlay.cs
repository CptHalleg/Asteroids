using Godot;
using System;

public partial class UI3DOverlay : Node
{
	public static UI3DOverlay Instance;

    public override void _EnterTree()
    {
        Instance = this;
    }
}
