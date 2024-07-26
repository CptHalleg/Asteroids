using Godot;
using System;

[GlobalClass]
public partial class SelfDestructor : Node
{
	[Export] public AudioSystemStream destructionSound;

	public void SelfDestruct(){
		AudioSystem.Play(destructionSound);
		GetParent().QueueFree();
	}
}
