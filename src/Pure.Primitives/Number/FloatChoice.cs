using Pure.Primitives.Bool;
using System;

namespace Pure.Primitives.Number;

public sealed record FloatChoice : IFloat
{
    private readonly IBool _condition;

    private readonly IFloat _valueOnTrue;

    private readonly IFloat _valueOnFalse;

    public FloatChoice(IBool condition, IFloat valueOnTrue, IFloat valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    float IFloat.Value => _condition.Value ? _valueOnTrue.Value : _valueOnFalse.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}