using Godot;
using Godot.NativeInterop;
using System;
using System.Dynamic;

[GlobalClass]
public partial class CooldownTimer : Node
{
	[Export] public float Cooldown = 1;
	[Export] public bool AutoUse = false;
	[Signal] public delegate void StartedCooldownEventHandler();
	public double ReadyBy{get; private set;}
	public double TimeLeft{
		get{
			return Math.Clamp(ReadyBy - Time.GetUnixTimeFromSystem(),0d,double.MaxValue);
		}
	}
	public bool IsReady{
		get{
			return ReadyBy <= Time.GetUnixTimeFromSystem();
		}
	}


	public void EnableAutouse(){
		AutoUse = true;
	}

	public void DisableAutouse(){
		AutoUse = false;
	}

    public override void _Process(double delta)
    {
		if(AutoUse){
        	Use();
		}
    }

    public virtual bool Use(){
		if(ReadyBy > Time.GetUnixTimeFromSystem()){
			return false;
		}
		ReadyBy =  Time.GetUnixTimeFromSystem() + Cooldown;
		EmitSignal(SignalName.StartedCooldown);
		return true;
	}
}
