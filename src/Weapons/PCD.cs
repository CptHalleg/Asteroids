using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public partial class PCD : Spawner
{

	[Export] private float MaxAngle = 1;
	[Export] public float BulletSpeed = 100;
    [Export] public float Inaccuracy { get; private set; } = 0.05f;

    public Node2D Target;
	private RandomNumberGenerator random = new RandomNumberGenerator();

    public override void _Process(double delta)
	{
		Target = GetClosestTarget();
		if(Target != null && IsInstanceValid(Target)){
			ShootDirection(QuickMafs.CalculateLeadDirection(GlobalPosition,BulletSpeed,Target.GlobalPosition, ((SimpleRigidbody2D)Target).Velocity - GetParent<Ship>().Velocity));
		}
	}

	public bool ShootDirection(Vector2 direction){

		if(Mathf.Abs(GlobalTransform.BasisXform(Vector2.Up).AngleTo(direction)) > MaxAngle){
			return false;
		}

		if(!Spawn(out Projectile bullet)){
			return false;
		}


		direction = direction.Rotated(random.RandfRange(-Inaccuracy, 0.05f));
		bullet.Velocity = direction * BulletSpeed;
		bullet.Velocity += GetParent<Ship>().Velocity;
		bullet.GlobalPosition = GlobalPosition;
		return true;;
	}

    public override void _Draw()
    {
        DrawLine(Vector2.Zero, Vector2.Up.Rotated(MaxAngle) * 100, Colors.Red);
        DrawLine(Vector2.Zero, Vector2.Up.Rotated(-MaxAngle) * 100, Colors.Red);
    }
}
