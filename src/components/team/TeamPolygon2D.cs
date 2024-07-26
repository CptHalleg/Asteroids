using Godot;
using System;

[GlobalClass]
public partial class TeamPolygon2D : Polygon2D
{
	[Export] public Color PlayerTeamColor;
	[Export] public Color EnemyTeamColor;
	[Export] public TeamMarker TeamMarker;

    public override void _EnterTree()
    {
		UpdateColor(TeamMarker.Team);
		TeamMarker.TeamChanged += UpdateColor;
    }

	public void UpdateColor(Team team){
		if(team == Team.Player){
			Color = PlayerTeamColor;
		}else if(team == Team.Enemy){
			Color = EnemyTeamColor;
		}
	}
}
