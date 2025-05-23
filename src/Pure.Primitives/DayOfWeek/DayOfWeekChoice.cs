using Pure.Primitives.Bool;
using Pure.Primitives.Number;
using System;

namespace Pure.Primitives.DayOfWeek;

public sealed record DayOfWeekChoice : IDayOfWeek
{
    private readonly IBool _condition;

    private readonly IDayOfWeek _valueOnTrue;

    private readonly IDayOfWeek _valueOnFalse;

    public DayOfWeekChoice(IBool condition, IDayOfWeek valueOnTrue, IDayOfWeek valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    IInt IDayOfWeek.DayNumber => _condition.Value ? _valueOnTrue.DayNumber : _valueOnFalse.DayNumber;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}