using Godot;
using System;

[GlobalClass]
public partial class DamagableArea : TeamArea2D
{
	[Signal] public delegate void DamagedEventHandler(DamageDealer damageDealer);
	public void Damage(DamageDealer damageDealer){
		EmitSignal(SignalName.Damaged, damageDealer);
	}
}
