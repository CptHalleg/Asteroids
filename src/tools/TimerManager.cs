using Godot;
using System;

public partial class TimerManager : Node
{
	public static TimerManager Instance {get; private set;}
	public override void _EnterTree()
	{
		Instance = this;
	}

	public static Timer SetTimer(float time, Action callback){
		Timer timer = new Timer();
		Instance.AddChild(timer);
		timer.WaitTime = time;
		timer.Timeout += callback;
		timer.Timeout += () => OnTimerTimeout(timer);
		timer.Start();
		return timer;
	}

    private static void OnTimerTimeout(Timer timer)
    {
        timer.QueueFree();
    }
}
