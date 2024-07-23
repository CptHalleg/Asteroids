using Godot;
using System;
using System.Diagnostics;

public partial class Spawner : Node2D
{
	[Export] public PackedScene spawnScene;
	[Export] public double WaitTime {get{return timer.WaitTime;} set{timer.WaitTime = value;}}
	[Export] public AudioStream SpawnAudioSteam;
	[Signal] public delegate void SpawnedEventHandler(Node2D spawnedNode);
	private Timer timer = new Timer{WaitTime = 1};

    public virtual void Spawn()
    {
		Node2D spawn = spawnScene.Instantiate<Node2D>();
		World.Instance.AddChild(spawn);
		spawn.GlobalPosition = GlobalPosition;
		AudioSystem.Play(SpawnAudioSteam, 1, 5);
		EmitSignal(SignalName.Spawned, spawn);
    }

    public override void _EnterTree()
    {
		timer.Timeout += () => Spawn();
		AddChild(timer);
    }

	public void StartSpawning(){
		timer.Start();
	}

	public void StopSpawning(){
		timer.Stop();
	}
}
