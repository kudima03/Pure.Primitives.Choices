using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Choices.Number;

public sealed record NumberChoice<T> : INumber<T> where T : System.Numerics.INumber<T>
{
    private readonly IBool _condition;

    private readonly INumber<T> _valueOnTrue;

    private readonly INumber<T> _valueOnFalse;

    public NumberChoice(IBool condition, INumber<T> valueOnTrue, INumber<T> valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    T INumber<T>.NumberValue => _condition.BoolValue ? _valueOnTrue.NumberValue : _valueOnFalse.NumberValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}