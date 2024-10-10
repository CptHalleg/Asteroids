using Godot;
using System;

public abstract partial class Attachment<A, H> : ShipComponent where A : Attachment<A, H> where H : HardpointShipComponent<A,H>
{
    public H Hardpoint{get; private set;}

    public override void _EnterTree()
    {
		DebugTools.IsParentType(typeof(H), this);
		Hardpoint = GetParent<H>();
		Hardpoint.SetAttached(this);
    }
	
	public virtual void OnAttach(){

	}
	public virtual void OnDetach(){
		
	}
}
