using Godot;
using System;

public class TargetChangedEvent : CharacterEvent
{
	public Node2D Target{get; private set;}
	public TargetChangedEvent(Node2D target) : base() {
		Target = target;
	}
}
