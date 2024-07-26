using Godot;
using System;

[GlobalClass]
public partial class Projectile : SimpleRigidbody2D
{
	public TeamMarker TeamMarker;
	public Timer despawnTimer;
	public override void _EnterTree()
	{
        TeamMarker = GetChild<TeamMarker>(0);
		despawnTimer = new Timer();
		AddChild(despawnTimer);
		despawnTimer.Timeout += OnDespawnTimerTimeout;
	}

    protected virtual void OnDespawnTimerTimeout()
    {
        QueueFree();
    }
}
