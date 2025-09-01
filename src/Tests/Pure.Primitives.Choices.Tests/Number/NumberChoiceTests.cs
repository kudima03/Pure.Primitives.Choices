using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Number;

namespace Pure.Primitives.Choices.Tests.Number;

using Double = Primitives.Number.Double;

public sealed record NumberChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        INumber<double> valueOnTrue = new Double(1.01);
        INumber<double> valueOnFalse = new Double(0.01);
        INumber<double> choice = new NumberChoice<double>(
            new True(),
            valueOnTrue,
            valueOnFalse
        );
        Assert.Equal(valueOnTrue.NumberValue, choice.NumberValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        INumber<double> valueOnTrue = new Double(1.01);
        INumber<double> valueOnFalse = new Double(0.01);
        INumber<double> choice = new NumberChoice<double>(
            new False(),
            valueOnTrue,
            valueOnFalse
        );
        Assert.Equal(valueOnFalse.NumberValue, choice.NumberValue);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new NumberChoice<double>(
                new True(),
                new Double(1.01),
                new Double(0.01)
            ).GetHashCode()
        );
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new NumberChoice<double>(
                new False(),
                new Double(1.01),
                new Double(0.01)
            ).ToString()
        );
    }
}
