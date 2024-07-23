using Godot;
using System;

[Tool]
public partial class World : Node2D
{
	public static World Instance;


    public override void _EnterTree()
    {
        Instance = this;
    }
}
