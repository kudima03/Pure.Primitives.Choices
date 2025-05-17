using Pure.Primitives.Bool;
using System;

namespace Pure.Primitives.Number;

public sealed record UIntChoice : IUInt
{
    private readonly IBool _condition;

    private readonly IUInt _valueOnTrue;

    private readonly IUInt _valueOnFalse;

    public UIntChoice(IBool condition, IUInt valueOnTrue, IUInt valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    uint IUInt.Value => _condition.Value ? _valueOnTrue.Value : _valueOnFalse.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}