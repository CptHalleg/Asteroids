using Godot;
using System;

[GlobalClass]
public partial class FireingArcVisualizer : Node2D
{
	private FireingArc fireingArc;
	public override void _Ready()
	{
		DebugTools.IsParentType(typeof(FireingArc), this);
		fireingArc = GetParent<FireingArc>();
		VisibilityLayer = 0;
		SetVisibilityLayerBit(FireingArcVisibilityToggle.VisibilityMaskBit, true);
	}

    public override void _Draw()
    {
		if(fireingArc.MaxAngle < Mathf.Pi){
			DrawLine(Vector2.Zero, Vector2.Right.Rotated(fireingArc.MaxAngle) * fireingArc.Range, Colors.Red);
			DrawLine(Vector2.Zero, Vector2.Right.Rotated(-fireingArc.MaxAngle) * fireingArc.Range, Colors.Red);
			DrawArc(Vector2.Zero, fireingArc.Range, -fireingArc.MaxAngle, fireingArc.MaxAngle,50,Colors.Red);
		}else{
			DrawArc(Vector2.Zero,fireingArc.Range, -Mathf.Pi,Mathf.Pi,50, Colors.Red);
		}
    }
}
