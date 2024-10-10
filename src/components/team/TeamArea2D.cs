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
		DebugTools.IsSet(TeamMarker,this);
		DebugTools.IsSet(TeamMarker, this);
        UpdateColor(TeamMarker.Team);
		TeamMarker.TeamChanged += UpdateColor;
    }

    public void UpdateColor(Team team){
		int offset;
		if(team == Team.Player){
			offset = 1;
		}else if(team == Team.Enemy){
			offset = 9;
		}else{
			return;
		}

		
		CollisionLayer = 0;
		SetCollisionLayerValue((int)TargetType.Ship + offset, LayerShip);
		SetCollisionLayerValue((int)TargetType.Missle + offset, LayerMissle);
		SetCollisionLayerValue((int)TargetType.Bullet + offset, LayerBullet);
		
		if(team == Team.Player){
			offset = 9;
		}else if(team == Team.Enemy){
			offset = 1;
		}
		
		
		CollisionMask = 0;
		SetCollisionMaskValue((int)TargetType.Ship + offset, MaskShip);
		SetCollisionMaskValue((int)TargetType.Missle + offset, MaskMissle);
		SetCollisionMaskValue((int)TargetType.Bullet + offset, MaskBullet);
	}

	public void SetCollisionLayerMaskValue(Team team, TargetType type, bool value){

	}
}
