using Pure.Primitives.Bool;
using System;

namespace Pure.Primitives.Number;

public sealed record UShortChoice : IUShort
{
    private readonly IBool _condition;

    private readonly IUShort _valueOnTrue;

    private readonly IUShort _valueOnFalse;

    public UShortChoice(IBool condition, IUShort valueOnTrue, IUShort valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    ushort IUShort.Value => _condition.Value ? _valueOnTrue.Value : _valueOnFalse.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}