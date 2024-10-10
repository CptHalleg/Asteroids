using Godot;
using System;
using System.Collections.Generic;

public partial class CharacterEventHandler : Node
{
	private Dictionary<Type, CharacterEventCallback<CharacterEvent>> preEventHandlers = new Dictionary<Type, CharacterEventCallback<CharacterEvent>>();
	private Dictionary<Type, CharacterEventCallback<CharacterEvent>> postEventHandlers = new Dictionary<Type, CharacterEventCallback<CharacterEvent>>();
	public delegate void CharacterEventCallback<in T>(T e) where T : CharacterEvent;
	public delegate void CharacterEventCallback(CharacterEvent e);
	private Character character;
	public CharacterEventHandler(Character character)
	{
		this.character = character;
	}
	public void CauseEvent(CharacterEvent e)
	{
		if (preEventHandlers.ContainsKey(e.GetType()))
		{
			preEventHandlers[e.GetType()].Invoke(e);
		}

		if (e.Canceled)
		{
			e.Failed?.Invoke();
		}
		else
		{
			e.Execute?.Invoke();
			if (postEventHandlers.ContainsKey(e.GetType()))
			{
				postEventHandlers[e.GetType()]?.Invoke(e);
			}
		}
	}



	public void PreRegister<T>(CharacterEventCallback<CharacterEvent> func) where T : CharacterEvent
	{
		Add(func, typeof(T), preEventHandlers);
	}

	public void PreUnRegister<T>(CharacterEventCallback<CharacterEvent> func) where T : CharacterEvent
	{

		Remove(func, typeof(T), preEventHandlers);
	}

	public void PostRegister<T>(CharacterEventCallback<CharacterEvent> func) where T : CharacterEvent
	{
		Add(func, typeof(T), postEventHandlers);
	}

	public void PostUnRegister<T>(CharacterEventCallback<CharacterEvent> func) where T : CharacterEvent
	{
		Remove(func, typeof(T), postEventHandlers);
	}


	private void Add(CharacterEventCallback<CharacterEvent> func, Type type, Dictionary<Type, CharacterEventCallback<CharacterEvent>> dictionary)
	{
		if (!dictionary.ContainsKey(type))
		{
			dictionary[type] = func;
		}
		else
		{
			dictionary[type] += func;
		}
	}

	private void Remove(CharacterEventCallback<CharacterEvent> func, Type type, Dictionary<Type, CharacterEventCallback<CharacterEvent>> dictionary)
	{
		if (!dictionary.ContainsKey(type))
		{
			return;
		}
		dictionary[type] -= func;
	}
}