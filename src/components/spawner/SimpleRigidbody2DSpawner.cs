using Godot;
using System;

public partial class SimpleRigidbody2DSpawner : Node2DSpawner
{
	
	public SimpleRigidbody2D ReferenceRigidbody2D;

    public override void _Ready()
    {
		int count = 100;
		Node currentNode = this;
        while(ReferenceRigidbody2D == null && count > 0 && currentNode != null){
			if(currentNode is SimpleRigidbody2D simpleRigidbody2D){
				ReferenceRigidbody2D = simpleRigidbody2D;
			}
			count--;
			currentNode = currentNode.GetParent();
		}
    }

	
    protected override Node InstanciateNewNode()
    {
		SimpleRigidbody2D spawn = (SimpleRigidbody2D) base.InstanciateNewNode();
		if(ReferenceRigidbody2D != null){
			spawn.Velocity = ReferenceRigidbody2D.Velocity;
		}
        return spawn;
    }
}
