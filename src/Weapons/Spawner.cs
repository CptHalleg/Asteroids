using Godot;
using System;
using System.Diagnostics;

public partial class Spawner : Turret
{

	[Export]
	private PackedScene spawnScene;

	[Export]
	public double MaxReloadTime = 0.1;
	public double EarlyesNextShot = 0;


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

	protected bool Spawn<T>(out T spawn) where T : Node2D{
		if(Time.GetUnixTimeFromSystem() < EarlyesNextShot){
			spawn = null;
			return false;
		}
		EarlyesNextShot = Time.GetUnixTimeFromSystem() + MaxReloadTime;
		spawn = spawnScene.Instantiate<T>();
		World.Instance.AddChild(spawn);
		spawn.GlobalPosition = GlobalPosition;
		return true;
	}
}
