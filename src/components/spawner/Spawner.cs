using Godot;
using System;
using System.Diagnostics;

[GlobalClass]
public abstract partial class Spawner : Node2D
{
	public abstract void Spawn();
}
