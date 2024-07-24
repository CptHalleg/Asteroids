using Godot;
using System;
using System.Diagnostics;

public partial class Spawner : Node2D
{
	[Export] public PackedScene spawnScene;
	[Export] public AudioStream SpawnAudioSteam;
	[Signal] public delegate void SpawnedEventHandler(Node2D spawnedNode);

    public virtual void Spawn()
    {
		Node2D spawn = spawnScene.Instantiate<Node2D>();
		World.Instance.AddChild(spawn);
		spawn.GlobalPosition = GlobalPosition;
		AudioSystem.Play(SpawnAudioSteam, 1, 5);
		EmitSignal(SignalName.Spawned, spawn);
    }
}
