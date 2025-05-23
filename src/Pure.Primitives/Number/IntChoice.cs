using Pure.Primitives.Bool;
using System;

namespace Pure.Primitives.Number;

public sealed record IntChoice : IInt
{
    private readonly IBool _condition;

    private readonly IInt _valueOnTrue;

    private readonly IInt _valueOnFalse;

    public IntChoice(IBool condition, IInt valueOnTrue, IInt valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    int IInt.Value => _condition.Value ? _valueOnTrue.Value : _valueOnFalse.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}