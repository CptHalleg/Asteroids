using Godot;
using System.Diagnostics;

public class InvincibilityEffect : CharacterEffect
{
  private Timer timer;
  private StatType invinciblityStat;
  public InvincibilityEffect(Character character, StatType invinciblityStat) : base(character)
  {
    this.invinciblityStat = invinciblityStat;
  }

  protected override void OnStart()
  {
    character.CharacterEventHandler.PreRegister<TakeDamageEvent>(OnTakeDamage);
    timer = TimerManager.SetTimer(character.StatBlock.GetValue(invinciblityStat), OnTimeout);
  }

  protected override void OnCleanup()
  {
    character.CharacterEventHandler.PreUnRegister<TakeDamageEvent>(OnTakeDamage);
  }

  private void OnTimeout()
  {
    character.CharacterEffectManager.RemoveEffect(this);
  }

  private void OnTakeDamage(CharacterEvent e)
  {
    e.Cancel();
  }

  public override string GetDiscription()
  {
    return "invincibility " +  string.Format("{0:0.00}" ,timer.TimeLeft) + "s";
  }
}
