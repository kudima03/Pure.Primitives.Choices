using Pure.Primitives.Bool;
using System;

namespace Pure.Primitives.Number;

public sealed record LongChoice : ILong
{
    private readonly IBool _condition;

    private readonly ILong _valueOnTrue;

    private readonly ILong _valueOnFalse;

    public LongChoice(IBool condition, ILong valueOnTrue, ILong valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    long ILong.Value => _condition.Value ? _valueOnTrue.Value : _valueOnFalse.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}