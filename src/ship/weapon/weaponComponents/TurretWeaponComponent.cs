using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[GlobalClass]
public partial class TurretWeaponComponent : WeaponComponent
{
	[Export] public FireingArc fireingArc;
	[Export] public float BulletSpeed = 100;
	public SimpleRigidbody2D ReferenceRigidbody2D;
	public Node2D Rotor;
	public Node2D Target;

    public override void _Ready()
    {
		base._Ready();
        Rotor = GetChild<Node2D>(0);

		int count = 100;
		Node currentNode = this;
        while(ReferenceRigidbody2D == null && count > 0 && currentNode != null){
			if(currentNode is SimpleRigidbody2D simpleRigidbody2D){
				ReferenceRigidbody2D = simpleRigidbody2D;
			}
			count--;
			currentNode = currentNode.GetParent();
		}

		Weapon.Character.CharacterEventHandler.PostRegister<TargetChangedEvent>(OnTargetChanged);
    }

    public override void _Process(double delta)
     {
		if(Target == null || !IsInstanceValid(Target)){
			return;			
		}

		Vector2 targetVelicity = Vector2.Zero;
		if(Target is SimpleRigidbody2D simpleRigidbody2D){
			targetVelicity += simpleRigidbody2D.Velocity;
		}

		if(ReferenceRigidbody2D is SimpleRigidbody2D simpleRigidbody2D1){
			targetVelicity -= simpleRigidbody2D1.Velocity;
		}

		Vector2 directionToTarget = (Target.GlobalPosition-GlobalPosition).Normalized();
		
		//Vector2 directionToTarget = QuickMafs.CalculateLeadDirection(GlobalPosition, BulletSpeed, Target.GlobalPosition, targetVelicity);

		if(!fireingArc.InAnglePosition(Target.GlobalPosition)){
			return;
		}

		Rotor.GlobalRotation = directionToTarget.Angle();
    }

    private void OnTargetChanged(CharacterEvent characterEvent)
    {
		TargetChangedEvent e = characterEvent as TargetChangedEvent;
		Target = e.Target;
	}
}
