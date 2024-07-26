using Godot;
using System.Diagnostics;
using System.Numerics;

public partial class KeepDistanceAIBehavoir : Node
{
	private Ship ship;
	public Ship Target;

    public override void _Ready()
    {
        ship = GetParent<Ship>();
		SetTarget(PlayerController.playerShip);
    }

    public override void _Process(double delta)
    {
		Godot.Vector2 directionToTarget = Target.GlobalPosition - ship.GlobalPosition;

		float distanceToTarget = Target.GlobalPosition.DistanceTo(ship.GlobalPosition);

		float angleToTarget;
		if(distanceToTarget > 5000){
			angleToTarget = ship.GlobalTransform.BasisXform(Godot.Vector2.Up).AngleTo(directionToTarget);
		} else {
			angleToTarget = ship.GlobalTransform.BasisXform(-Godot.Vector2.Up).AngleTo(directionToTarget);
		}

		int control = 0;
		if(Mathf.Abs(angleToTarget) > 0.1f){
			if(angleToTarget < 0){
				control = -1;
			}else{
				control = 1;
			}
		}

		ship.ControlRotating = control;
		ship.ControlBoosting = true;
    }

	public void SetTarget(Ship target){
		Target = target;
	}
}
