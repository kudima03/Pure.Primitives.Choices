using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Choices.Bool;

public sealed record BoolChoice : IBool
{
    private readonly IBool _condition;

    private readonly IBool _valueOnTrue;

    private readonly IBool _valueOnFalse;

    public BoolChoice(IBool condition, IBool valueOnTrue, IBool valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    public bool BoolValue =>
        _condition.BoolValue ? _valueOnTrue.BoolValue : _valueOnFalse.BoolValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
