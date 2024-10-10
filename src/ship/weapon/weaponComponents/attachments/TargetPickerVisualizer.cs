using Godot;
using System;
using System.Diagnostics;

[GlobalClass]
public partial class TargetPickerVisualizer : Node
{
	private TargetPickerWeaponComponent targetPicker;
	private Line2D line2D;
	public override void _Ready()
	{
		DebugTools.IsParentType(typeof(TargetPickerWeaponComponent), this);
		targetPicker = GetParent<TargetPickerWeaponComponent>();
		line2D = new Line2D();
		AddChild(line2D);
		line2D.VisibilityLayer = 0;
		line2D.SetVisibilityLayerBit(FireingArcVisibilityToggle.VisibilityMaskBit, true);
		line2D.DefaultColor = Colors.Red;

		line2D.Points  = new Vector2[2];
	}


    public override void _Process(double delta)
    {
		if(targetPicker.Target == null || !IsInstanceValid(targetPicker.Target)){
        	line2D.SetPointPosition(0, Vector2.Zero);
			return;
		}
        line2D.SetPointPosition(0,line2D.ToLocal(targetPicker.Target.GlobalPosition));
    }
}
