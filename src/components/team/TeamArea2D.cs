using Godot;
using System;
using System.Diagnostics;

[GlobalClass]
public partial class TeamArea2D : Node
{
	private Area2D area2D;
	[Export] public bool LayerShip;
	[Export] public bool LayerMissle;
	[Export] public bool LayerBullet;

	[Export] public bool MaskShip;
	[Export] public bool MaskMissle;
	[Export] public bool MaskBullet;



	[Export] public TeamMarker TeamMarker;

    public override void _EnterTree()
    {
		area2D = GetParent<Area2D>();
        UpdateColor(TeamMarker.PlayerTeam);
		TeamMarker.TeamChanged += UpdateColor;
    }

    public void UpdateColor(bool team){
		int offset;
		if(team){
			offset = 0;
		}else{
			offset = 8;
		}
		
		area2D.CollisionLayer = 0;
		area2D.SetCollisionLayerValue(1 + offset, LayerShip);
		area2D.SetCollisionLayerValue(2 + offset, LayerMissle);
		area2D.SetCollisionLayerValue(3 + offset, LayerBullet);
		
		if(!team){
			offset = 0;
		}else{
			offset = 8;
		}
		
		area2D.CollisionMask = 0;
		area2D.SetCollisionMaskValue(1 + offset, MaskShip);
		area2D.SetCollisionMaskValue(2 + offset, MaskMissle);
		area2D.SetCollisionMaskValue(3 + offset, MaskBullet);
	}
}
