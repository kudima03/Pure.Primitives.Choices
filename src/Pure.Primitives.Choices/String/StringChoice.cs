using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.Choices.String;

public sealed record StringChoice : IString
{
    private readonly IBool _condition;

    private readonly IString _valueOnTrue;

    private readonly IString _valueOnFalse;

    public StringChoice(IBool condition, IString valueOnTrue, IString valueOnFalse)
    {
        _condition = condition;
        _valueOnTrue = valueOnTrue;
        _valueOnFalse = valueOnFalse;
    }

    string IString.Value => _condition.Value ? _valueOnTrue.Value : _valueOnFalse.Value;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}