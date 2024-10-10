using Godot;

[GlobalClass]
public partial class AddAttributeStatType : AttributeStatType{
    public override Stat NewStat(StatBlock statBlock)
    {
        return new AddAttributeStat(this, statBlock);
    }
}
