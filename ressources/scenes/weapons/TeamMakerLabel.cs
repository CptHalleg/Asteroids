using Godot;
using System;

public partial class TeamMakerLabel : Label
{
	private TeamMarker TeamMarker;
	public override void _Ready()
	{
		TeamMarker = GetParent<TeamMarker>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text = TeamMarker.Team.ToString();
	}
}
