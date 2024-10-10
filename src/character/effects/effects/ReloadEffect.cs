using Godot;
using System;

public class ReloadEffect : CharacterEffect
{
	public float ReloadTime { get; private set; }
	public float ReloadAmount { get; private set; }
	private Timer timer;
	public ReloadEffect(Character character, float reloadTime, float reloadAmount) : base(character)
	{
		ReloadTime = reloadTime;
		this.ReloadAmount = reloadAmount;
	}

	protected override void OnStart()
	{
		timer = TimerManager.SetTimer(ReloadTime, OnTimeout);
	}

	private void OnTimeout()
	{
		character.CharacterEventHandler.CauseEvent(new ReloadFinishEvent(ReloadAmount));
		Remove();
	}

	public override string GetDiscription()
	{
		return "Reloading " + string.Format("{0:0.00}", timer.TimeLeft) + "s";
	}
}
