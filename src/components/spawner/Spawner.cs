using Godot;
using System;
using System.Diagnostics;

[GlobalClass]
public partial class Spawner : Node2D
{
	[Export] public PackedScene spawnScene;
	[Export] public AudioSystemStream SpawnAudioSteam;
	[Signal] public delegate void SpawnedEventHandler(Node2D spawnedNode);

    public void Spawn()
    {
		if(spawnScene == null){
			return;
		}

		Node spawn = InstanciateNewNode();
		AudioSystem.Play(SpawnAudioSteam);
		EmitSignal(SignalName.Spawned, spawn);
    }
	protected virtual Node InstanciateNewNode(){
		Node spawn = spawnScene.Instantiate<Node>();
		World.Instance.AddChild(spawn);
		return spawn;
	}
}
