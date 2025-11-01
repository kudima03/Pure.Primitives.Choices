using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Choices.Char;

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

    public char CharValue =>
        _condition.BoolValue ? _valueOnTrue.CharValue : _valueOnFalse.CharValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
