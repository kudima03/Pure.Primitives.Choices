using System.Collections;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.String;

namespace Pure.Primitives.Choices.Tests.String;

using String = Primitives.String.String;

public sealed record StringChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IString valueOnTrue = new String("1");
        IString valueOnFalse = new String("0");
        IString choice = new StringChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnTrue.TextValue, choice.TextValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IString valueOnTrue = new String("1");
        IString valueOnFalse = new String("0");
        IString choice = new StringChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnFalse.TextValue, choice.TextValue);
    }

    [Fact]
    public void EnumeratesAsTyped()
    {
        IString valueOnTrue = new String("1");
        IString valueOnFalse = new String("0");
        IString choice = new StringChoice(new False(), valueOnTrue, valueOnFalse);

        Assert.True(
            valueOnFalse
                .Select(x => x.CharValue)
                .SequenceEqual(choice.Select(x => x.CharValue))
        );
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IString valueOnTrue = new String("1");
        IString valueOnFalse = new String("0");
        IEnumerable choice = new StringChoice(new False(), valueOnTrue, valueOnFalse);

        ICollection<IChar> symbols = [];

        foreach (object symbol in choice)
        {
            symbols.Add((symbol as IChar)!);
        }

        Assert.True(
            valueOnFalse
                .Select(x => x.CharValue)
                .SequenceEqual(symbols.Select(x => x.CharValue))
        );
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new StringChoice(
                new True(),
                new String("123"),
                new String("321")
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new StringChoice(new False(), new String("123"), new String("321")).ToString()
        );
    }
}
