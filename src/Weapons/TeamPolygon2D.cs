using Godot;
using System;

public partial class TeamPolygon2D : Polygon2D
{
	[Export] public Color PlayerTeamColor;
	[Export] public Color EnemyTeamColor;
	[Export] public TeamMarker TeamMarker;

    public override void _EnterTree()
    {
		UpdateColor(TeamMarker.PlayerTeam);
		TeamMarker.TeamChanged += UpdateColor;
    }

	public void UpdateColor(bool team){
		if(team){
			Color = PlayerTeamColor;
		}else{
			Color = EnemyTeamColor;
		}
	}
}
