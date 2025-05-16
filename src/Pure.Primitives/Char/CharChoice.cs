using Pure.Primitives.Bool;
using System;

namespace Pure.Primitives.Char;

public sealed record CharChoice : IChar
{
    private readonly IBool _condition;

    private readonly IChar _valueOnTrue;

    private readonly IChar _valueOnFalse;

    public CharChoice(IBool condition, IChar valueOnTrue, IChar valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    char IChar.Value => _condition.Value ? _valueOnTrue.Value : _valueOnFalse.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}