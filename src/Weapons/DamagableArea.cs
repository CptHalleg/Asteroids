using Godot;
using System;

public partial class DamagableArea : Area2D
{
	[Signal] public delegate void DamageedEventHandler(DamageDealer damageDealer);
	public void Damage(DamageDealer damageDealer){
		GetParent().QueueFree();
		EmitSignal(SignalName.Damageed, damageDealer);
	}
}
