using Godot;
using System;

[GlobalClass]
public partial class BaseStatValue : Resource
{
	[Export] public AttributeStatType AttributeStatType{get; private set;}
	[Export] public float Value{get; private set;}
}
