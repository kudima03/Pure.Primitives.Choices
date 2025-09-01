using System.Collections;
using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.Choices.String;

using Char = Primitives.Char.Char;

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

    string IString.TextValue => ValueInternal;

    public string ValueInternal =>
        _condition.BoolValue ? _valueOnTrue.TextValue : _valueOnFalse.TextValue;

    public IEnumerator<IChar> GetEnumerator()
    {
        return ValueInternal.Select(symbol => new Char(symbol)).GetEnumerator();
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
