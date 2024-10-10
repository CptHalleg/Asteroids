using Godot;

[GlobalClass]
public partial class CappedStatType : ResourceStatType{
	[Export] public StatType maxType;
    public override Stat NewStat(StatBlock statBlock)
    {
        return new CappedStat(this, statBlock, statBlock.GetStat(maxType));
    }
}
