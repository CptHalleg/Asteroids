using Godot;
using System;
using System.Diagnostics;

public static partial class DebugTools 
{
	[Conditional("DEBUG")]
	public static void IsSet(object obj, Node node){
		if(obj == null){
			Debug.WriteLine("Object not set in " + node.GetPath());
		}
	}

	[Conditional("DEBUG")]
    public static void IsParentType(Type type, Node node)
    {
        if(!type.IsAssignableFrom(node.GetParent().GetType())){
			Debug.WriteLine("Parrent is wrong type in " + node.GetPath() + " expected: " + type.Name + " current: " + node.GetParent().GetType().Name);
		}
    }

	[Conditional("DEBUG")]
    internal static void IsChildType(Type type, int nr, Node node)
    {
        if(!type.IsAssignableFrom(node.GetChild(nr).GetType())){
			Debug.WriteLine("Child "+ nr +" is wrong type in " + node.GetPath());
		}
    }

	

	[Conditional("DEBUG")]
    internal static void IsChild(Node child, Node parent)
    {
        if(child.GetParent()  != parent){
			Debug.WriteLine(child.GetPath() + " is not a child of " + parent.GetPath());
		}
    }

}
