using Pure.Primitives.Bool;
using System;

namespace Pure.Primitives.Number;

public sealed record DoubleChoice : IDouble
{
    private readonly IBool _condition;

    private readonly IDouble _valueOnTrue;

    private readonly IDouble _valueOnFalse;

    public DoubleChoice(IBool condition, IDouble valueOnTrue, IDouble valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    double IDouble.Value => _condition.Value ? _valueOnTrue.Value : _valueOnFalse.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}