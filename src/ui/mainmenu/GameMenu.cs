using Godot;
using System;

public partial class GameMenu : Control
{
	[Export] private Button backToMenuButton;
	[Export] private PackedScene mainMenuScene;

    public override void _Ready()
    {
        backToMenuButton.ButtonUp += OnExitToMenu;
		Visible = false;
    }

    public override void _Input(InputEvent @event)
    {
        if(@event.IsActionPressed("game_menu")){
			Visible = !Visible;
            GetTree().Paused = !GetTree().Paused;
		}
    }

    private void OnExitToMenu()
    {
        GetTree().Paused = false;
        SceneManager.ChangeToMainMenu();
    }
}
