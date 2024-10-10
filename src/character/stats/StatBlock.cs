using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Markup;

public class StatBlock
{
	private Dictionary<StatType, Stat> values;

    public StatBlock(){
        values = new Dictionary<StatType, Stat>();
    }

    public Stat GetStat(StatType type)
    {
        if(type == null){
            return null;
        }
        return values[type];
    }

    public T GetStat<T>(StatType type) where T : Stat
    {
        return (T) GetStat(type);
    }

    public float GetValue(StatType type, float def){
        Stat stat = GetStat(type);
        if(stat == null){
            return def;
        }
        return stat.GetValue();
    }

    public float GetValue(StatType type){
        return GetStat(type).GetValue();
    }

    public void InitStatType(StatType type){
        values.Add(type, type.NewStat(this));
    }

    public IReadOnlyDictionary<StatType, Stat> GetValues(){
        return values;
    }

}
