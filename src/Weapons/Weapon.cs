using Godot;
using System;
using System.Collections.Generic;

public partial class Turret : Node2D
{
	[Export] public float MaxRange{get; private set;} = 1000;

	public float MaxRangeSquared{get; private set;}
	protected List<Node2D> targetsInRange;

    public override void _Ready()
    {
        GetChild<Area2D>(0).AreaEntered += OnAreaEntered;
        GetChild<Area2D>(0).AreaExited += OnAreaExited;
		targetsInRange = new List<Node2D>();
		MaxRangeSquared = MaxRange * MaxRange;
    }

    private void OnAreaExited(Area2D area)
    {
		targetsInRange.Remove(area.GetParent<Torpedo>());
    }

    private void OnAreaEntered(Area2D area)
    {
		targetsInRange.Add(area.GetParent<Torpedo>());
    }


	public Node2D GetClosestTarget(){
		float minRange = float.MaxValue;
		SimpleRigidbody2D minTarget = null;
		foreach(SimpleRigidbody2D currentTarget in targetsInRange){
			float currentRange = currentTarget.GlobalPosition.DistanceSquaredTo(GlobalPosition);
			if(currentRange < minRange && isValidTarget(currentTarget)){
				minRange = currentRange;
				minTarget = currentTarget;
			}
		}
		return minTarget;
	}
}
