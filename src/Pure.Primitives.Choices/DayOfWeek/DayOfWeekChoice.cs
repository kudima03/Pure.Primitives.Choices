using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.DayOfWeek;
using Pure.Primitives.Abstractions.Number;

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

    INumber<int> IDayOfWeek.DayNumber => _condition.Value ? _valueOnTrue.DayNumber : _valueOnFalse.DayNumber;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}