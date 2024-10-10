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

	public static bool HasCapacity(AudioStream stream, int maxConcurrent){
		if(!Instance.PlayingAudioSteams.ContainsKey(stream)){
			Instance.PlayingAudioSteams.Add(stream,0);
		}

		if(Instance.PlayingAudioSteams[stream] > maxConcurrent){
			return false;
		}
		Instance.PlayingAudioSteams[stream]++;
		return true;
	}

	public static AudioStreamPlayer InitAudioSteamPlayer(AudioSystemStream audio){
		AudioStreamPlayer audioStreamPlayer = new AudioStreamPlayer();
		audioStreamPlayer.Stream = audio.AudioStream;
		audioStreamPlayer.VolumeDb = audio.Volume;
		Instance.AddChild(audioStreamPlayer);
		audioStreamPlayer.Play();
		return audioStreamPlayer;
	}

	public static void CleanupAudioSteamPlayer(AudioStreamPlayer audioStreamPlayer){
		audioStreamPlayer.Stop();
		audioStreamPlayer.QueueFree();
		Instance.PlayingAudioSteams[audioStreamPlayer.Stream]--;
		if(Instance.PlayingAudioSteams[audioStreamPlayer.Stream] <= 0){
			Instance.PlayingAudioSteams.Remove(audioStreamPlayer.Stream);
		}
	}

	public static void Play(AudioSystemStream audio){

		if(audio == null || audio.AudioStream == null){
			return;
		}

		if(!HasCapacity(audio.AudioStream, audio.MaxConcurrent)){
			return;
		}

		AudioStreamPlayer audioStreamPlayer = InitAudioSteamPlayer(audio);
		audioStreamPlayer.Finished += () =>
		{
			CleanupAudioSteamPlayer(audioStreamPlayer);
		};
	}

    public static void Loop(AudioSystemStream audio, object source)
    {
		if(audio == null || audio.AudioStream == null || source == null){
			return;
		}

		if(!HasCapacity(audio.AudioStream, audio.MaxConcurrent)){
			return;
		}

		Dictionary<AudioStream, AudioStreamPlayer> sourceSounds;
        if(!Instance.loopingAudioSteams.ContainsKey(source)){
			sourceSounds = new Dictionary<AudioStream, AudioStreamPlayer> ();
			Instance.loopingAudioSteams.Add(source,sourceSounds);
		}else{
			sourceSounds = Instance.loopingAudioSteams[source];
		} 

		if(sourceSounds.ContainsKey(audio.AudioStream)){
			return;
		}

		AudioStreamPlayer audioStreamPlayer = InitAudioSteamPlayer(audio);
		audioStreamPlayer.Finished += () => audioStreamPlayer.Play();
		sourceSounds.Add(audio.AudioStream,audioStreamPlayer);
    }

	public static void StopLoop(AudioSystemStream audio, object source)
    {

		if(audio == null || audio.AudioStream == null || source == null){
			return;
		}

        if(!Instance.loopingAudioSteams.ContainsKey(source)){
			return;
		}

		Dictionary<AudioStream, AudioStreamPlayer> sourceSounds = Instance.loopingAudioSteams[source];

		if(!sourceSounds.ContainsKey(audio.AudioStream)){
			return;
		}

		AudioStreamPlayer audioStreamPlayer = sourceSounds[audio.AudioStream];
		if(audioStreamPlayer == null){
			return;
		}

		CleanupAudioSteamPlayer(audioStreamPlayer);
		sourceSounds.Remove(audio.AudioStream);

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
			CleanupAudioSteamPlayer(audioStreamPlayer);
		}

		Instance.loopingAudioSteams.Remove(source);

    }
}
