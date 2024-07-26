using Godot;
using System;

[GlobalClass]
public partial class AudioSystemStream : Resource
{
	[Export] public AudioStream AudioStream;
	[Export] public float Volume = 0;
	[Export] public int MaxConcurrent = 3;
}
