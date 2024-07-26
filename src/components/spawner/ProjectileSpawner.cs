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

		Vector2 direction = GlobalTransform.BasisXform(Vector2.Up) * ProjectileSpeed;
		direction = direction.Rotated(random.RandfRange(-Inaccuracy, Inaccuracy));
		spawn.Velocity += direction;
		spawn.despawnTimer.WaitTime = ProjectileLifeTime;
		spawn.despawnTimer.Start();
		spawn.TeamMarker.PlayerTeam = TeamMarker.PlayerTeam;
		return spawn;
    }

    public void OnSpawned(Node node)
    {
        /*Projectile projectile = (Projectile) node;
		
		AudioSystem.Play(SpawnAudioSteam, -30,1);
		EmitSignal(SignalName.Spawned, projectile);*/
    }
}
