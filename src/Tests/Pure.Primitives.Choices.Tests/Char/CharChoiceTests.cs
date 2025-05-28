using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Char;

namespace Pure.Primitives.Choices.Tests.Char;

using Char = Primitives.Char.Char;

public sealed record CharChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IChar valueOnTrue = new Char('A');
        IChar valueOnFalse = new Char('B');
        IChar choice = new CharChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnTrue.CharValue, choice.CharValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IChar valueOnTrue = new Char('A');
        IChar valueOnFalse = new Char('B');
        IChar choice = new CharChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnFalse.CharValue, choice.CharValue);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new CharChoice(new True(), new Char('A'), new Char('B')).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new CharChoice(new False(), new Char('A'), new Char('B')).ToString());
    }
}