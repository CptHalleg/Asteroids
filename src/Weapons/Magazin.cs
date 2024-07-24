using Godot;
using System;

public partial class Magazin : Node
{
	[Export] public int MaxCapacity = 10;
	[Export] public float FullReloadTime = 1;
	[Export] public float ReloadAmount = 10;
	[Signal] public delegate void StartedFullRealoadEventHandler();
	[Signal] public delegate void UsedCapacityEventHandler();
	public int CurrentCount;
	public double ReloadFinishTime;

    public override void _Ready()
    {
        CurrentCount = MaxCapacity;
    }

	public bool UseCapacity(){
		if(IsReloading()){
			return false;
		}

		if(CurrentCount <= 0){
			FullReload();
			return false;
		}

		CurrentCount = CurrentCount - 1;
		EmitSignal(SignalName.UsedCapacity);
		return true;
	}

	public void FullReload(){
		EmitSignal(SignalName.StartedFullReaload);
		CurrentCount = MaxCapacity;
		ReloadFinishTime = Time.GetUnixTimeFromSystem() + FullReloadTime;
	}

	public bool IsReloading(){
		return Time.GetUnixTimeFromSystem() < ReloadFinishTime;
	}

	public float FullReloadTimeLeft(){
		return (float) Math.Clamp(ReloadFinishTime - Time.GetUnixTimeFromSystem(), 0, double.MaxValue);
	}
}
