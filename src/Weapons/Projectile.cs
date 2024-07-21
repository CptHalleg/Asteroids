using Godot;
using System;

public partial class Projectile : SimpleRigidbody2D
{
	private Timer timer;
	[Export] public int piercing = 1;
	[Export] public float LifeTime{get; private set;} = 2;
	public override void _Ready()
	{
		timer = new Timer();
		AddChild(timer);
		timer.WaitTime = LifeTime;
		timer.Timeout += OnTimerTimeout;
		timer.Start();
		
        GetChild<Area2D>(0).AreaEntered += OnCollision;
	}

    private void OnCollision(Area2D area)
    {
        area.GetParent().QueueFree();
		piercing--;
		if(piercing <= 0){
			QueueFree();
		}
    }


    private void OnTimerTimeout()
    {
        QueueFree();
    }

}
