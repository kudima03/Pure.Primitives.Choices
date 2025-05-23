using Pure.Primitives.Bool;
using Pure.Primitives.Number;

namespace Pure.Primitives.Tests.Number;

using Double = Primitives.Number.Double;

public sealed record DoubleChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IDouble valueOnTrue = new Double(1.01);
        IDouble valueOnFalse = new Double(0.01);
        IDouble choice = new DoubleChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnTrue.Value, choice.Value);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IDouble valueOnTrue = new Double(1.01);
        IDouble valueOnFalse = new Double(0.01);
        IDouble choice = new DoubleChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnFalse.Value, choice.Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new DoubleChoice(new True(), new Double(1.01), new Double(0.01)).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new DoubleChoice(new False(), new Double(1.01), new Double(0.01)).ToString());
    }
}