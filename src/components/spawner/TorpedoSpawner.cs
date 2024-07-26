using Godot;
using System;

[GlobalClass]
public partial class TorpedoSpawner : ProjectileSpawner
{
	public Node2D Target;
	protected override Node InstanciateNewNode()
    {
        Torpedo torpedo = (Torpedo)base.InstanciateNewNode();
		torpedo.Target = Target;
		return torpedo;
    }

    private void SetTarget(Node2D target)
    {
		Target = target;
	}
}
