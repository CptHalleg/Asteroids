using Godot;
using System;

public class StatModifier
{
	private float value;

    public StatModifier(float value)
    {
        this.value = value;
    }

    public float GetValue(){
		return value;
	}
}
