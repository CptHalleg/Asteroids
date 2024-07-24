using Godot;
using System;

public partial class MagazinDisplay : Label
{
	private Magazin magazin;
	public override void _Ready()
	{
		magazin = GetParent<Magazin>();
	}

	public override void _Process(double delta)
	{
		Text = magazin.CurrentCount + "/" + magazin.MaxCapacity;
	}
}
