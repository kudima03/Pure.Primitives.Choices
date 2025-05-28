using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Guid;

namespace Pure.Primitives.Choices.Guid;

public sealed record GuidChoice : IGuid
{
    private readonly IBool _condition;

    private readonly IGuid _valueOnTrue;

    private readonly IGuid _valueOnFalse;

    public GuidChoice(IBool condition, IGuid valueOnTrue, IGuid valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    System.Guid IGuid.GuidValue => _condition.BoolValue ? _valueOnTrue.GuidValue : _valueOnFalse.GuidValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}