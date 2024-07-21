using Godot;
using System;

public partial class QuickMafs
{
	public static Vector2 CalculateLead(Vector2 shooterPos,float bulletSpeed,Vector2 targetPos,Vector2 targetVel) {

					
		float a = bulletSpeed*bulletSpeed - targetVel.Dot(targetVel);
		float b = 2*targetVel.Dot(targetPos-shooterPos);
		float c = (targetPos-shooterPos).Dot(targetPos-shooterPos);
		
		float time = 0.0f;
		if (bulletSpeed > targetVel.Length()){
			time = (b+Mathf.Sqrt(b*b+4*a*c)) / (2*a);
		}
			
		return targetPos+time*targetVel;
	}

	public static Vector2 CalculateLeadDirection(Vector2 shooterPos,float bulletSpeed,Vector2 targetPos,Vector2 targetVel){
		Vector2 interceptPos = CalculateLead(shooterPos, bulletSpeed, targetPos, targetVel);
		Vector2 interceptDirection = interceptPos - shooterPos;
		return interceptDirection.Normalized();
	}
}
