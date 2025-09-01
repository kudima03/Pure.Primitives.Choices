using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Choices.Date;

public sealed record DateChoice : IDate
{
    private readonly IBool _condition;

    private readonly IDate _valueOnTrue;

    private readonly IDate _valueOnFalse;

    public DateChoice(IBool condition, IDate valueOnTrue, IDate valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    public INumber<ushort> Day =>
        _condition.BoolValue ? _valueOnTrue.Day : _valueOnFalse.Day;

    public INumber<ushort> Month =>
        _condition.BoolValue ? _valueOnTrue.Month : _valueOnFalse.Month;

    public INumber<ushort> Year =>
        _condition.BoolValue ? _valueOnTrue.Year : _valueOnFalse.Year;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
