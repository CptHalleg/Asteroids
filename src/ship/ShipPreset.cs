using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class ShipPreset : Resource
{
	[Export] public PackedScene ShipScene;
	[Export] private Array<PackedScene> weapons;
	[Export] private Array<PackedScene> drives;
	[Export] private Array<PackedScene> rotators;
}
