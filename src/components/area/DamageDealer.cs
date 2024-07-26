using Godot;
using System;
using System.Diagnostics;

[GlobalClass]
public partial class DamageDealer : Node
{
    [Signal] public delegate void DealtDamageEventHandler(DamagableArea damagableArea);
	private Area2D area2D;

    public override void _Ready()
    {
        area2D = GetParent<Area2D>();
		area2D.AreaEntered += OnCollision;
    }

    private void OnCollision(Area2D otherArea2D)
    {
        if(!(otherArea2D is DamagableArea damagableArea)){
			return;
		}

		damagableArea.Damage(this);
        EmitSignal(SignalName.DealtDamage, damagableArea);
	}

}
