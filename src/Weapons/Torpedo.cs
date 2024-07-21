using Godot;
using System;
using System.ComponentModel;

public partial class Torpedo : Projectile
{
	[Export] float Acceleration = 100;
	[Export] public float TimeToArm{get; private set;} = 1;
	public float VisualRotationSpeed = 0.05f;
	public float VisualRotationSpeedMax = 10;
	float Speed = 0;
	public bool IsArmed  = false;
	public SimpleRigidbody2D Target;
	private Vector2 interceptPos;
	private Timer timer;
	private Node2D visuals;

    public override void _Ready()
    {
        GetChild<Area2D>(0).AreaEntered += OnCollision;
		visuals = GetChild<Node2D>(1);
		timer = new Timer();
		timer.WaitTime = TimeToArm;
		timer.Timeout += OnTimerTimeout;
		AddChild(timer);
		timer.Start();
	}

    private void OnTimerTimeout()
    {
        IsArmed = true;
		Speed = Velocity.Length();
    }


    private void OnCollision(Area2D area)
    {
        QueueFree();
    }

    public override void _Process(double delta)
	{
		
		visuals.Rotation += (float)delta * Mathf.Clamp(Speed * VisualRotationSpeed, 0, VisualRotationSpeedMax);
		if(IsArmed){
			Speed += Acceleration * (float)delta;
			if(Target != null){
				Velocity = (Target.GlobalPosition - GlobalPosition).Normalized() * Speed;
			}
		}
	}
}
