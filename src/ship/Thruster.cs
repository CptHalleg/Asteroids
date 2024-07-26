using Godot;
using System;

public partial class Thruster : Node2D
{
	[Export] public AudioSystemStream ActiveSound;
	private Node2D visuals;
	private Area2D flamebox;
	public bool Active;

	public override void _EnterTree()
	{
		visuals = GetChild<Node2D>(0);
		flamebox = GetChild<Area2D>(1);
	}

    public override void _Process(double delta)
    {
		if(Active){
			flamebox.ProcessMode  = ProcessModeEnum.Inherit;
			AudioSystem.Loop(ActiveSound, this);
		}else{
			flamebox.ProcessMode  = ProcessModeEnum.Disabled;
			AudioSystem.StopLoop(ActiveSound, this);
		}
		visuals.Visible = Active;
    }

	public void SetActive(bool active){
		Active = active;
	}

    public override void _ExitTree()
    {
        AudioSystem.StopAllLoops(this);
    }
}
