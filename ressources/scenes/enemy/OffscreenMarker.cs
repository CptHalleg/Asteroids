using Godot;
using System;

public partial class OffscreenMarker : Node2D
{
	[Export] public float Zoom;
	private VisibleOnScreenNotifier2D visibleOnScreenNotifier2D;
	public override void _Ready()
	{
		visibleOnScreenNotifier2D = GetChild<VisibleOnScreenNotifier2D>(0);
		visibleOnScreenNotifier2D.ScreenEntered += OnScreenEntered;
		visibleOnScreenNotifier2D.ScreenExited += OnScreenExited;

		if(!visibleOnScreenNotifier2D.IsOnScreen()){
			OnScreenExited();
		}
	}

    private void OnScreenEntered()
    {
        
        SubviewportManager.Instance.ReleaseOffscreenMarker(this);
    }


    private void OnScreenExited()
    {
        SubviewportManager.Instance.RequestOffscreenMarker(this);
    }

    public override void _ExitTree()
    {
        SubviewportManager.Instance.ReleaseOffscreenMarker(this);
    }

}
