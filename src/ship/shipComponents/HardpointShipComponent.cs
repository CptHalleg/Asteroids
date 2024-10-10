using Godot;
using System;

public abstract partial class HardpointShipComponent<A, H> : ShipComponent where A : Attachment<A, H> where H :HardpointShipComponent<A,H>
{
	public A Attachment{get; private set;}

	public void SetAttached(Attachment<A, H> newAttachment){
		DebugTools.IsChild(newAttachment, this);
		if(Attachment != null){
			Attachment.OnDetach();
		}
		Attachment = (A)newAttachment;
		Attachment.OnAttach();
	}
}
