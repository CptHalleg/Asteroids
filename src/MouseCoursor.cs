using Godot;
using System;

public partial class MouseCoursor : Polygon2D
{
    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseMotion mouseMotion){
			Position = mouseMotion.Position;
		}
    }

    public override void _Notification(int what)
    {
        if(what == NotificationWMMouseEnter){
			Visible = true;
			Input.MouseMode = Input.MouseModeEnum.Hidden;
		}else if(what == NotificationWMMouseExit){
			Visible = false;
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}
    }
}
