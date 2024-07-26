using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class TargetPicker : Area2D
{
	[Export] public FireingArc FireingArc;
	[Signal] public delegate void TargetChangedEventHandler(Node2D newTarget);
	[Signal] public delegate void TargetAcquiredEventHandler();
	[Signal] public delegate void TargetLostEventHandler();
	public Node2D Target = null;
	public float MaxRangeSquared{get; private set;} = 0;
	private List<Node2D> targetsInRange = new List<Node2D>();
    public CircleShape2D CircleShape2D = new CircleShape2D();

    public override void _Ready()
    {
		base._Ready();
		CircleShape2D circleShape2D = new CircleShape2D();
		circleShape2D.Radius = FireingArc.Range;
		CollisionShape2D collisionShape2D = new CollisionShape2D{Shape = circleShape2D};
		AddChild(collisionShape2D);
        AreaEntered += OnAreaEntered;
        AreaExited += OnAreaExited;
    }

    private void OnAreaExited(Area2D area)
    {
		targetsInRange.Remove(area.GetParent<Node2D>());
    }

    private void OnAreaEntered(Area2D area)
    {
		targetsInRange.Add(area.GetParent<Node2D>());
    }

	private Node2D GetClosestTarget(){
		float minRange = float.MaxValue;
		Node2D minTarget = null;
		foreach(Node2D currentTarget in targetsInRange){
			float currentRange = currentTarget.GlobalPosition.DistanceSquaredTo(GlobalPosition);
			if(currentRange < minRange && FireingArc.ContainsAngle(currentTarget.GlobalPosition - GlobalPosition)){
				minRange = currentRange;
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
