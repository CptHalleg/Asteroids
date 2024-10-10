using Godot;
using System;

[GlobalClass]
public partial class Projectile : SimpleRigidbody2D
{
	public TeamMarker TeamMarker;
	public Timer despawnTimer;
	public override void _Ready()
	{
		despawnTimer.Start();
	}

	public void Init(Vector2 direction, float despawnTime, Team team){
        TeamMarker = GetChild<TeamMarker>(0);
		despawnTimer = new Timer();
		AddChild(despawnTimer);
		despawnTimer.Timeout += OnDespawnTimerTimeout;

		
		Velocity += direction;
		despawnTimer.WaitTime = despawnTime;
		TeamMarker.Team = team;
	}

    protected virtual void OnDespawnTimerTimeout()
    {
        QueueFree();
    }
}
