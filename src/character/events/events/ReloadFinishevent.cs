using Godot;
using System;

public  class ReloadFinishEvent : CharacterEvent
{
    public float ReloadAmout;
	public ReloadFinishEvent(float reloadAmount){
		this.ReloadAmout = reloadAmount;
	}
}
