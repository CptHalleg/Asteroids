using Godot;
using System;

public partial class MainMenu : Node
{
	[Export] private Button startGameButton;
	[Export] private Button shipyardButton;
	[Export] private Button exitGameButton;
	[Export] private PackedScene startGameScene;
	[Export] private PackedScene shipyardScene;
	
	public override void _Ready()
	{
		DebugTools.IsSet(startGameButton, this);
		DebugTools.IsSet(exitGameButton, this);

		startGameButton.ButtonUp += OnStartGame;
		shipyardButton.ButtonUp += OnShipyard;
		exitGameButton.ButtonUp += OnExitGame;
	}

    private void OnExitGame()
    {
		GetTree().Quit();
    }

    private void OnStartGame()
    {
		SceneManager.ChangeScene(startGameScene.Instantiate());
    }

	 private void OnShipyard()
    {
		SceneManager.ChangeScene(shipyardScene.Instantiate());
    }
}
