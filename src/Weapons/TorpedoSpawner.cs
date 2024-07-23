using Godot;
using System;

public partial class TorpedoSpawner : ProjectileSpawner
{
	public Node2D Target;
	public override void Spawn()
    {
        Torpedo torpedo = spawnScene.Instantiate<Torpedo>();
		World.Instance.AddChild(torpedo);
		torpedo.GlobalPosition = GlobalPosition;
		Vector2 direction = GlobalTransform.BasisXform(Vector2.Up) * ProjectileSpeed;
		direction = direction.Rotated(random.RandfRange(-Inaccuracy, Inaccuracy));
		if(ReferenceRigidbody2D != null){
			direction = direction + ReferenceRigidbody2D.Velocity;
		}
		torpedo.Shoot(ProjectileLifeTime, direction, Target, TeamMarker.PlayerTeam);
		EmitSignal(SignalName.Spawned, torpedo);
    }

    private void SetTarget(Node2D target)
    {
		Target = target;
	}
}
