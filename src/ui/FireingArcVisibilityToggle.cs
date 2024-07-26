using Godot;
using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

public partial class FireingArcVisibilityToggle : Node
{
	public const uint VisibilityMaskBit = 1;

    public override void _EnterTree()
    {
		GetViewport().SetCanvasCullMaskBit(VisibilityMaskBit, false);
    }

    public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("show_fireing_arcs")){
			GetViewport().SetCanvasCullMaskBit(VisibilityMaskBit, true);
		}else if(Input.IsActionJustReleased("show_fireing_arcs")){
			GetViewport().SetCanvasCullMaskBit(VisibilityMaskBit, false);
		}
	}
}
