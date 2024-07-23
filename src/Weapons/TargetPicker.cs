using Godot;
using System;
using System.Collections.Generic;

public partial class TargetPicker : Area2D
{
	[Export] public float MaxRange{get{return CircleShape2D.Radius;} private set{CircleShape2D.Radius = value;}}
	[Export] public float MaxAngle = 1;
	[Export] public bool DisplayRange = false;
	[Signal] public delegate void TargetChangedEventHandler(Node2D newTarget);
	[Signal] public delegate void TargetAcquiredEventHandler();
	[Signal] public delegate void TargetLostEventHandler();
	public Node2D Target = null;
	public float MaxRangeSquared{get; private set;} = 0;
	private List<Node2D> targetsInRange = new List<Node2D>();
    public CircleShape2D CircleShape2D =new CircleShape2D{Radius = 1000};

    public override void _Ready()
    {
		base._Ready();
		CollisionShape2D collisionShape2D = new CollisionShape2D{Shape = CircleShape2D};
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
			if(currentRange < minRange && Mathf.Abs(GlobalTransform.BasisXform(Vector2.Up).AngleTo(currentTarget.GlobalPosition - GlobalPosition)) < MaxAngle){
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

    public override void _Draw()
    {
		if(!DisplayRange){
			return;
		}

		if(MaxAngle < Mathf.Pi){
			DrawLine(Vector2.Zero, Vector2.Up.Rotated(MaxAngle) * MaxRange, Colors.Red);
			DrawLine(Vector2.Zero, Vector2.Up.Rotated(-MaxAngle) * MaxRange, Colors.Red);
			DrawArc(Vector2.Zero, MaxRange, -MaxAngle - Mathf.Pi/2, MaxAngle - Mathf.Pi/2,50,Colors.Red);
		}else{
			DrawArc(Vector2.Zero,MaxRange, -Mathf.Pi,Mathf.Pi,50, Colors.Red);
		}
    }
}
