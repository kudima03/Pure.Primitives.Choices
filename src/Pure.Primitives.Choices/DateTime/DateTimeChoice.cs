using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Choices.DateTime;

public sealed record DateTimeChoice : IDateTime
{
    private readonly IBool _condition;

    private readonly IDateTime _valueOnTrue;

    private readonly IDateTime _valueOnFalse;

    public DateTimeChoice(IBool condition, IDateTime valueOnTrue, IDateTime valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    public INumber<ushort> Day => _condition.BoolValue ? _valueOnTrue.Day : _valueOnFalse.Day;

    public INumber<ushort> Month => _condition.BoolValue ? _valueOnTrue.Month : _valueOnFalse.Month;

    public INumber<ushort> Year => _condition.BoolValue ? _valueOnTrue.Year : _valueOnFalse.Year;

    public INumber<ushort> Hour => _condition.BoolValue ? _valueOnTrue.Hour : _valueOnFalse.Hour;

    public INumber<ushort> Minute => _condition.BoolValue ? _valueOnTrue.Minute : _valueOnFalse.Minute;

    public INumber<ushort> Second => _condition.BoolValue ? _valueOnTrue.Second : _valueOnFalse.Second;

    public INumber<ushort> Millisecond => _condition.BoolValue ? _valueOnTrue.Millisecond : _valueOnFalse.Millisecond;

    public INumber<ushort> Microsecond => _condition.BoolValue ? _valueOnTrue.Microsecond : _valueOnFalse.Microsecond;

    public INumber<ushort> Nanoseconds => _condition.BoolValue ? _valueOnTrue.Nanoseconds : _valueOnFalse.Nanoseconds;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}