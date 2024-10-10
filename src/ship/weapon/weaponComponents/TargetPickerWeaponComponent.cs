using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[GlobalClass]
public partial class TargetPickerWeaponComponent : WeaponComponent
{
	[Export] public FireingArc FireingArc;
	[Export] public TeamMarker TeamMarker;
	[Export] public TargetType Type;
	public Node2D Target = null;
	public float MaxRangeSquared{get; private set;} = 0;

    public override void _Ready()
    {
		base._Ready();
        DebugTools.IsSet(TeamMarker, this);
		Weapon.Character.CharacterEventHandler.PreRegister<FireWeaponEvent>(OnFireWeapon);
    }

    private void OnFireWeapon(CharacterEvent e)
    {
		if(Target == null){
			e.Cancel();
		}
    }


    private Node2D GetClosestTarget(){
		float minRangeSquared = float.MaxValue;
		Node2D minTarget = null;
		foreach(Targetable currentTarget in TargetList.GetTargets(TeamMarker.Team.Opposition(), Type)){
			if(!IsInstanceValid(currentTarget)){
				continue;
			}
			float currentRangeSquared = currentTarget.GlobalPosition.DistanceSquaredTo(GlobalPosition);
			if(currentRangeSquared < minRangeSquared && FireingArc.InRangeSquaredPosition(currentTarget.GlobalPosition) && FireingArc.InAnglePosition(currentTarget.GlobalPosition)){
				minRangeSquared = currentRangeSquared;
				minTarget = currentTarget;
			}
		}
		return minTarget;
	}

    public override void _PhysicsProcess(double delta)
    {
        Node2D newTarget = GetClosestTarget();
		if(Target != newTarget){
			Weapon.Character.CharacterEventHandler.CauseEvent(new TargetChangedEvent(newTarget));
			Target = newTarget;
		}
    }
}
