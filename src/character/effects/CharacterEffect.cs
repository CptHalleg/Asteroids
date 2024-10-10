using Godot;
using System;
using System.Runtime.CompilerServices;

public abstract class CharacterEffect
{
    protected Character character;
    public event Event Cleanedup;
    public event Event Started;
    public bool Active{get; private set;}
    public delegate void Event();

    public CharacterEffect(Character character){
        this.character = character;
    }

    protected virtual void OnStart(){

    }

    protected virtual void OnCleanup(){

    }

    public  void Start(){
        OnStart();
        Started?.Invoke();
        Active = true;
    }

    public void Cleanup(){
        OnCleanup();
        Active = false;
        Cleanedup?.Invoke();
    }

    public virtual string GetDiscription()
    {
        return "";
    }

    public void Remove(){
        character.CharacterEffectManager.RemoveEffect(this);
    }

}
