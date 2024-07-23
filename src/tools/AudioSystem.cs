using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public partial class AudioSystem : Node
{
	public static AudioSystem Instance {get; private set;}

	private Dictionary<AudioStream, int> PlayingAudioSteams = new Dictionary<AudioStream, int>();
	private Dictionary<object, Dictionary<AudioStream, AudioStreamPlayer>> loopingAudioSteams = new Dictionary<object, Dictionary<AudioStream, AudioStreamPlayer>>();

    public override void _EnterTree()
    {
        Instance = this;
    }

	public static void Play(AudioStream audio, float Volume, int MaxActive){
		if(!Instance.PlayingAudioSteams.ContainsKey(audio)){
			Instance.PlayingAudioSteams.Add(audio,0);
		}

		if(Instance.PlayingAudioSteams[audio] > MaxActive){
			return;
		}
		Instance.PlayingAudioSteams[audio]++;

		AudioStreamPlayer audioStreamPlayer = new AudioStreamPlayer();
		audioStreamPlayer.Stream = audio;
		audioStreamPlayer.VolumeDb = Volume;
		audioStreamPlayer.Finished += () =>{ audioStreamPlayer.QueueFree(); Instance.PlayingAudioSteams[audio]--;};
		Instance.AddChild(audioStreamPlayer);
		audioStreamPlayer.Play();
	}

    public static void Loop(AudioStream audio, float volume, object source)
    {
		Dictionary<AudioStream, AudioStreamPlayer> sourceSounds;
        if(!Instance.loopingAudioSteams.ContainsKey(source)){
			sourceSounds = new Dictionary<AudioStream, AudioStreamPlayer> ();
			Instance.loopingAudioSteams.Add(source,sourceSounds);
		}else{
			sourceSounds = Instance.loopingAudioSteams[source];
		} 

		if(sourceSounds.ContainsKey(audio)){
			return;
		}

		Debug.WriteLine("starting loop adio");

		AudioStreamPlayer audioStreamPlayer = new AudioStreamPlayer();
		sourceSounds.Add(audio,audioStreamPlayer);
		audioStreamPlayer.Stream = audio;
		audioStreamPlayer.VolumeDb = volume;
		audioStreamPlayer.Finished += () => audioStreamPlayer.Play();
		Instance.AddChild(audioStreamPlayer);
		audioStreamPlayer.Play();
    }

	 public static void StopLoop(AudioStream audio, object source)
    {
        if(!Instance.loopingAudioSteams.ContainsKey(source)){
			return;
		}

		Dictionary<AudioStream, AudioStreamPlayer> sourceSounds = Instance.loopingAudioSteams[source];

		if(!sourceSounds.ContainsKey(audio)){
			return;
		}

		AudioStreamPlayer audioStreamPlayer = sourceSounds[audio];
		if(audioStreamPlayer == null){
			return;
		}

		audioStreamPlayer.Stop();
		audioStreamPlayer.QueueFree();
		sourceSounds.Remove(audio);
		if(sourceSounds.Count <= 0){
			Instance.loopingAudioSteams.Remove(source);
		}
    }

    internal static void StopAllLoops(object source)
    {
        if(!Instance.loopingAudioSteams.ContainsKey(source)){
			return;
		}

		Dictionary<AudioStream, AudioStreamPlayer> sourceSounds = Instance.loopingAudioSteams[source];

		foreach(AudioStreamPlayer audioStreamPlayer in sourceSounds.Values){
			audioStreamPlayer.Stop();
			audioStreamPlayer.QueueFree();
		}

		Instance.loopingAudioSteams.Remove(source);

    }
}
