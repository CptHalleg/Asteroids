using Godot;
using System;

public partial class Projectile : SimpleRigidbody2D
{
	protected TeamMarker teamMarker;
	protected Timer despawnTimer;
	public override void _EnterTree()
	{
        teamMarker = GetChild<TeamMarker>(0);
	}

	public void Shoot(float lifeTime, Vector2 velocilty, bool PlayerTeam){
		despawnTimer = new Timer();
		AddChild(despawnTimer);
		despawnTimer.WaitTime = lifeTime;
		despawnTimer.Timeout += OnDespawnTimerTimeout;
		despawnTimer.Start();

		Velocity = velocilty;

		teamMarker.PlayerTeam = PlayerTeam;
	}


    protected virtual void OnDespawnTimerTimeout()
    {
        QueueFree();
    }
}
