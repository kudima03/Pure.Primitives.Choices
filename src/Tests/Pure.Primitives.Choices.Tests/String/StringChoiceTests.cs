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
        Assert.Equal(valueOnTrue.Value, choice.Value);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IString valueOnTrue = new String("1");
        IString valueOnFalse = new String("0");
        IString choice = new StringChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnFalse.Value, choice.Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new StringChoice(new True(), new String("123"), new String("321")).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new StringChoice(new False(), new String("123"), new String("321")).ToString());
    }
}