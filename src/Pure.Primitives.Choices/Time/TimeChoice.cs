using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Abstractions.Time;

namespace Pure.Primitives.Choices.Time;

public sealed record TimeChoice : ITime
{
    private readonly IBool _condition;

    private readonly ITime _valueOnTrue;

    private readonly ITime _valueOnFalse;

    public TimeChoice(IBool condition, ITime valueOnTrue, ITime valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

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