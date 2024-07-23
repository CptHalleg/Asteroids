using Godot;
using System;

public partial class PDC : Node2D
{
	[Export] public TargetPicker TargetPicker;
	[Export] public Projectile Spawner;
	[Export] public Magazin magazin;
	[Export] public TeamMarker TeamMarker;
}
