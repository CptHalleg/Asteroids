using Godot;
using System;
using System.Diagnostics;

[GlobalClass]
public partial class TeamArea2D : Area2D
{
	[Export] public bool LayerShip;
	[Export] public bool LayerMissle;
	[Export] public bool LayerBullet;

	[Export] public bool MaskShip;
	[Export] public bool MaskMissle;
	[Export] public bool MaskBullet;



	[Export] public TeamMarker TeamMarker;

    public override void _EnterTree()
    {
		DebugTools.IsSet(TeamMarker, this);
        UpdateColor(TeamMarker.Team);
		TeamMarker.TeamChanged += UpdateColor;
    }

    public void UpdateColor(Team team){
		int offset;
		if(team == Team.Player){
			offset = 0;
		}else if(team == Team.Enemy){
			offset = 8;
		}else{
			offset = 16;
		}
		
		CollisionLayer = 0;
		SetCollisionLayerValue(1 + offset, LayerShip);
		SetCollisionLayerValue(2 + offset, LayerMissle);
		SetCollisionLayerValue(3 + offset, LayerBullet);
		
		if(team == Team.Player){
			offset = 8;
		}else if(team == Team.Enemy){
			offset = 0;
		}else{
			offset = 16;
		}
		
		
		CollisionMask = 0;
		SetCollisionMaskValue(1 + offset, MaskShip);
		SetCollisionMaskValue(2 + offset, MaskMissle);
		SetCollisionMaskValue(3 + offset, MaskBullet);
	}
}
