using Godot;
using System;

[GlobalClass]
public partial class MagazinReloadTimer : Timer
{
	private Magazin magazin;
	public override void _Ready()
	{
		magazin = GetParent<Magazin>();
		OneShot = true;
		magazin.StartedReload += () => Start(0);
		Timeout += () => magazin.FinishReload();
	}
}
