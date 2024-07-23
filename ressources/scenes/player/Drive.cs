using Godot;
using System;

public partial class Drive : Node2D
{
	[Export] public AudioStream ActiveSound;
	[Export] public float BoostPower = 200;
	private Ship ship;
	private Node2D visuals;
	private Area2D flamebox;

	public override void _EnterTree()
	{
		visuals = GetChild<Node2D>(0);
		flamebox = GetChild<Area2D>(1);
		ship = GetParent<Ship>();
	}

    public override void _Process(double delta)
    {
		if(ship.ControlBoosting){
			ship.Velocity += ship.GlobalTransform.BasisXform(Vector2.Up) * BoostPower * (float)delta;
			flamebox.ProcessMode  = ProcessModeEnum.Inherit;
			AudioSystem.Loop(ActiveSound, -20, this);
		}else{
			flamebox.ProcessMode  = ProcessModeEnum.Disabled;
			AudioSystem.StopLoop(ActiveSound, this);
		}
		visuals.Visible = ship.ControlBoosting;
    }

    public override void _ExitTree()
    {
        AudioSystem.StopAllLoops(this);
    }
}
