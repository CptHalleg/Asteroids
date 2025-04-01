using Godot;
using System;

public partial class TakeDamageEvent : CharacterEvent
{
    public float Damage{get; private set;}
    public TakeDamageEvent(float damage) : base(){
        Damage = damage;
    }
}
