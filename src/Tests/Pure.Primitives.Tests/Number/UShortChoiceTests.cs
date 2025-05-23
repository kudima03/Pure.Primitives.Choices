using Pure.Primitives.Bool;
using Pure.Primitives.Number;

namespace Pure.Primitives.Tests.Number;

public sealed record UShortChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IUShort valueOnTrue = new UShort(1);
        IUShort valueOnFalse = new UShort(0);
        IUShort choice = new UShortChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnTrue.Value, choice.Value);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IUShort valueOnTrue = new UShort(1);
        IUShort valueOnFalse = new UShort(0);
        IUShort choice = new UShortChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnFalse.Value, choice.Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new UShortChoice(new True(), new UShort(1), new UShort(0)).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new UShortChoice(new False(), new UShort(1), new UShort(0)).ToString());
    }
}