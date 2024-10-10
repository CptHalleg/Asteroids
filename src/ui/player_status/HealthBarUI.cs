using Godot;
using System;

public partial class HealthBarUI : HBoxContainer
{
	[Export] private StatType statType;
	[Export] private PackedScene heartScene;
	public Ship Ship;
	private Stat stat;


    public override void _Ready()
    {
    }

    public override void _Process(double delta)
	{
		stat = Ship.Character.StatBlock.GetStat<CappedStat>(statType);
		int actualChildCount = GetChildCount();
		while(actualChildCount != stat.GetValue()){
			if(actualChildCount > stat.GetValue()){
				GetChild(actualChildCount-1).QueueFree();
				actualChildCount--;
			}else{
				Node n = heartScene.Instantiate();
				actualChildCount++;
				AddChild(n);
			}
		}
	}
}
