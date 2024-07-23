using Godot;
using System;

public partial class ProjectileSpawner : Spawner
{
	[Export] public float ProjectileSpeed = 100;
	[Export] public float ProjectileLifeTime = 2;
    [Export] public float Inaccuracy { get; private set; } = 0.05f;
	[Export] public TeamMarker TeamMarker;
	public SimpleRigidbody2D ReferenceRigidbody2D;
	protected RandomNumberGenerator random = new RandomNumberGenerator();

    public override void _Ready()
    {
		int count = 100;
		Node currentNode = this;
        while(ReferenceRigidbody2D == null && count > 0 && currentNode != null){
			if(currentNode is SimpleRigidbody2D simpleRigidbody2D){
				ReferenceRigidbody2D = simpleRigidbody2D;
			}
			count--;
			currentNode = currentNode.GetParent();
		}
    }

    public override void Spawn()
    {
        Projectile projectile = spawnScene.Instantiate<Projectile>();
		World.Instance.AddChild(projectile);
		projectile.GlobalPosition = GlobalPosition;
		Vector2 direction = GlobalTransform.BasisXform(Vector2.Up) * ProjectileSpeed;
		direction = direction.Rotated(random.RandfRange(-Inaccuracy, Inaccuracy));
		if(ReferenceRigidbody2D != null){
			direction = direction + ReferenceRigidbody2D.Velocity;
		}
		projectile.Shoot(ProjectileLifeTime, direction, TeamMarker.PlayerTeam);
		AudioSystem.Play(SpawnAudioSteam, -30,1);
		EmitSignal(SignalName.Spawned, projectile);
    }
}
