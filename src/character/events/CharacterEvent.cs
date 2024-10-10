using Godot;
using System;

public partial class CharacterEvent
{
	public bool Canceled{get; private set;} = false;
	public Action Execute;
	public Action Failed;

	public CharacterEvent(){
	}

	public void Cancel(){
		Canceled = true;
	}
}
