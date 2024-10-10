using Godot;

[GlobalClass]
public partial class MultiAttributeStatType : AttributeStatType{
    [Export] public StatType baseStatType;
    public override Stat NewStat(StatBlock statBlock)
    {
        return new MultAttributeStat(this, statBlock, statBlock.GetStat(baseStatType));
    }
}
