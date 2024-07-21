using Godot;
using System;
using System.Collections.Generic;

public partial class TorpedoLauncher : Spawner
{
	[Export]
	public SimpleRigidbody2D Target;

    public override void _Ready()
    {
        GetChild<Area2D>(0).AreaEntered += OnAreaEntered;
        GetChild<Area2D>(0).AreaExited += OnAreaExited;
    }

    private void OnAreaExited(Area2D area)
    {
		Target = null;
    }


    private void OnAreaEntered(Area2D area)
    {
        Target = area.GetParent<SimpleRigidbody2D>();
    }


    public override void _Process(double delta)
	{
		if(Target != null){
			ShootDirection();
		}
	}

	public bool ShootDirection(){
		if(!Spawn(out Torpedo torpedo)){
			return false;
		}
		torpedo.Target = Target;
		torpedo.Velocity = GlobalTransform.BasisXform(Vector2.Up) * 100;
		return true;;
	}
}
