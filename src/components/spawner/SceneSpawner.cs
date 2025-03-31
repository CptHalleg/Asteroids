using Godot;
using System;

public partial class SceneSpawner : Spawner
{
	[Export] public PackedScene spawnScene;
	[Export] public AudioSystemStream SpawnAudioSteam;
	[Signal] public delegate void SpawnedEventHandler(Node2D spawnedNode);

    public override void Spawn()
    {
		if(spawnScene == null){
			return;
		}

		Node spawn = InstanciateNewNode();
		World.Instance.AddChild(spawn);
		AudioSystem.Play(SpawnAudioSteam);
		EmitSignal(SignalName.Spawned, spawn);
    }
	protected virtual Node InstanciateNewNode(){
		Node spawn = spawnScene.Instantiate<Node>();
		return spawn;
	}
}
