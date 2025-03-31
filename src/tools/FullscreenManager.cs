using Godot;
using System;

public partial class FullscreenManager : Node
{
	private bool _fullscreen;
	public bool Fullscreen{
		get{
			return _fullscreen;
		}
		set{
			if(value){
				DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
			}else{
				DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
			}
			_fullscreen = value;
		}
	}

    public override void _Ready()
    {
        Fullscreen = false;
    }

    public override void _Input(InputEvent @event)
    {
        if(@event.IsActionPressed("toggle_fullscreen")){
			Fullscreen = !Fullscreen;
		}
    }
}
