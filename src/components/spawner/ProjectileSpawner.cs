using Godot;
using System;

[GlobalClass]
public partial class ProjectileSpawner : SimpleRigidbody2DSpawner
{
	[Export] public float ProjectileSpeed = 100;
	[Export] public float ProjectileLifeTime = 2;
    [Export] public float Inaccuracy { get; private set; } = 0.05f;
	[Export] public TeamMarker TeamMarker;
	protected RandomNumberGenerator random = new RandomNumberGenerator();
    protected override Node InstanciateNewNode()
    {
		Projectile spawn = (Projectile) base.InstanciateNewNode();
		Vector2 direction = GlobalTransform.BasisXform(Vector2.Right) * ProjectileSpeed;
		direction = direction.Rotated(random.RandfRange(-Inaccuracy, Inaccuracy));
		spawn.Init(direction, ProjectileLifeTime, TeamMarker.Team);
		return spawn;
    }
}
