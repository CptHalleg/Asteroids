using Godot;
using System;

public partial class SceneManager : Node
{
	public static SceneManager Instance{get; private set;}
	[Export] private PackedScene mainMenu;
	private Node currentScene;

    public override void _EnterTree()
    {
		Instance = this;
		currentScene = GetChild(0);
    }

    public static void ChangeScene(Node newScene){
		Instance.RemoveChild(Instance.currentScene);
		Instance.currentScene.QueueFree();
		Instance.AddChild(newScene);
		Instance.currentScene = newScene;
	}

	public static void ChangeToMainMenu(){
		ChangeScene(Instance.mainMenu.Instantiate());
	}
}
