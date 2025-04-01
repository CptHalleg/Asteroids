using Godot;
using System;

public class FireWeaponEvent : CharacterEvent
{
    public Weapon Weapon;
    public FireWeaponEvent(Weapon weapon) : base()
    {
        Weapon = weapon;
    }

}
