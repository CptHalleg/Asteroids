using Godot;
using System;

public partial class LocationRandomizer : Node
{
	[Export] public float Radius;
	[Export] public bool RandomizeAtReady;
	[Signal] public delegate void RandomizedEventHandler();
	public Vector2 AnchorPosition;
	private Node2D node2D;
	private RandomNumberGenerator random = new RandomNumberGenerator();
	public override void _Ready()
	{
		node2D = GetParent<Node2D>();
		AnchorPosition = node2D.GlobalPosition;
		if(RandomizeAtReady){
			Randomize();
		}
	}

	public void Randomize(){
		float distance = random.RandfRange(0, Radius);
		float angle = random.RandfRange(0, Mathf.Pi * 2);
		Vector2 randomPos = Vector2.Up.Rotated(angle) * distance;
		node2D.GlobalPosition = randomPos + AnchorPosition;
		EmitSignal(SignalName.Randomized);
	}
}
