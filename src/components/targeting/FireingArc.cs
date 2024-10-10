using Godot;
using System;

[GlobalClass]
public partial class FireingArc : Node2D
{
    [Signal] public delegate void RangeChangedEventHandler(float newRange);
    [Signal] public delegate void RangeSquaredChangedEventHandler(float newRange);
	[Export] public float MaxAngle = 1;
	[Export] public float Range{
        get{
            if(isRangeDirty){
                _range = Mathf.Sqrt(_rangeSquared);
            }
            return _range;
        }
        set{
            if(value == _range){
                return;
            }

            EmitSignal(SignalName.RangeChanged, value);
            _range = value;
            isRangeSquaredDirty = true;
        }
    }
	public float RangeSquared{
        get{
            if(isRangeSquaredDirty){
                _rangeSquared = _range * _range;
            }
            return _rangeSquared;
        }
        set{
            if(value == _rangeSquared){
                return;
            }

            EmitSignal(SignalName.RangeSquaredChanged, value);
            _rangeSquared = value;
            isRangeDirty = true;
        }
    }

    private float _range;
    private float _rangeSquared;
    private bool isRangeDirty = false;
    private bool isRangeSquaredDirty = true;

    public void SetRangeAndRangeSquared(float range, float rangeSqared){
        _range = range;
        _rangeSquared = rangeSqared;
        isRangeDirty = false;
        isRangeSquaredDirty = false;
    }

    public bool InRangeSquaredPosition(Vector2 globalPosition){
        return GlobalPosition.DistanceSquaredTo(globalPosition) < RangeSquared;
    }

    public bool InRangePosition(Vector2 globalPosition){
        return GlobalPosition.DistanceTo(globalPosition) < Range;
    }

    public bool InAngle(float angle){
        return Mathf.Abs(angle) < MaxAngle;
    }

    public bool InAnglePosition(Vector2 globalPosition)
    {
        return Mathf.Abs(GlobalTransform.BasisXform(Vector2.Right).AngleTo(globalPosition - GlobalPosition)) < MaxAngle;
    }
}
