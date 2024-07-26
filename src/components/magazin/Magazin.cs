using Godot;
using System;
using System.Dynamic;

[GlobalClass]
public partial class Magazin : Node
{
	[Export] public int MaxCapacity = 10;
	[Export] public int CurrentCount = 10;
	[Export] public bool Reloading {get; private set;} = false;
	[Export] public bool AutoReload = false;
	[Signal] public delegate void ConsumedCapacityEventHandler();
	[Signal] public delegate void StartedReloadEventHandler();
	[Signal] public delegate void FinishedReloadEventHandler();

    public bool ConsumeCapacity(){
		if(Reloading){
			return false;
		}

		if(CurrentCount <= 0){
			if(AutoReload){
				CurrentCount = MaxCapacity;
				StartReload();
			}
			return false;
		}

		CurrentCount = CurrentCount - 1;
		EmitSignal(SignalName.ConsumedCapacity);
		return true;
	}

	public bool StartReload(){
		if(Reloading){
			return false;
		}
		Reloading = true;
		EmitSignal(SignalName.StartedReload);

		return true;
	}

	public bool FinishReload(){
		if(!Reloading){
			return false;
		}
		Reloading = false;
		CurrentCount = MaxCapacity;
		EmitSignal(SignalName.FinishedReload);
		return true;
	}
}
