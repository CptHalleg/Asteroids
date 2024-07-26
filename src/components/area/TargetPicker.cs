using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class TargetPicker : Node2D
{
	[Signal] public delegate void TargetChangedEventHandler(Node2D newTarget);
	[Signal] public delegate void TargetAcquiredEventHandler();
	[Signal] public delegate void TargetLostEventHandler();
	[Export] public FireingArc FireingArc;
	[Export] public TeamMarker TeamMarker;
	[Export] public TargetType Type;
	public Node2D Target = null;
	public float MaxRangeSquared{get; private set;} = 0;

	private Node2D GetClosestTarget(){
		float minRangeSquared = float.MaxValue;
		Node2D minTarget = null;
		foreach(Node2D currentTarget in TargetList.GetTargets(TeamMarker.Team.Opposition(), Type)){
			float currentRangeSquared = currentTarget.GlobalPosition.DistanceSquaredTo(GlobalPosition);
			if(currentRangeSquared < minRangeSquared && FireingArc.InRangeSquaredPosition(currentTarget.GlobalPosition) && FireingArc.InAnglePosition(currentTarget.GlobalPosition)){
				minRangeSquared = currentRangeSquared;
				minTarget = currentTarget;
			}
		}
		return minTarget;
	}

    public override void _Process(double delta)
    {
        Node2D newTarget = GetClosestTarget();
		if(Target != newTarget){
			EmitSignal(SignalName.TargetChanged, newTarget);
			if(newTarget == null){
				EmitSignal(SignalName.TargetLost);
			}else if(newTarget != null && Target == null){
				EmitSignal(SignalName.TargetAcquired);
			}
			Target = newTarget;
		}
    }
}
