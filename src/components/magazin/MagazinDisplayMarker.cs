using Godot;
using System;

public partial class MagazinDisplayMarker : Node
{
	[Export] public string DisplayName;
	[Export] public bool Display = false;
	[Export] public Timer timer;
	private Label label;
	private Magazin magazin;
	public override void _Ready()
	{
		magazin = GetParent<Magazin>();
		if(Display){
			label = PlayerShipStatusUI.Instance.AddMagazinLabel();
		}
	}	
	
	public override void _Process(double delta)
	{
		if(label == null){
			return;
		}

		
		if(timer != null && timer.TimeLeft != 0){
			label.Text = DisplayName + ": " + string.Format("{0:0.00}", timer.TimeLeft) + "s";
			return;
		}
		
		label.Text = DisplayName + ": " + magazin.CurrentCount + "/" + magazin.MaxCapacity;
		
	}
}
