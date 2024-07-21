using Godot;
using System;

public partial class ImageGenerator : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		int size = 10000;
		RandomNumberGenerator rand = new RandomNumberGenerator();
		Image image = Image.Create(size,size,false,Image.Format.Rgba8);
		for(int i = 0; i < 1000; i++){
			image.SetPixel((int)rand.RandfRange(0,size),(int)rand.RandfRange(0,size), new Color(1,1,1,1f));
		}
		Texture = ImageTexture.CreateFromImage(image);
		//image.SavePng("test.png");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
