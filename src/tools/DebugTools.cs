using Godot;
using System;
using System.Diagnostics;

public static partial class DebugTools 
{
	[Conditional("DEBUG")]
	public static void IsSet(object obj, Node parent){
		if(obj == null){
			Debug.WriteLine("Object not set in " + parent.GetPath());
		}
	}
}
