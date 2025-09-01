using Pure.Primitives.Abstractions.DayOfWeek;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.DayOfWeek;
using Pure.Primitives.DayOfWeek;

namespace Pure.Primitives.Choices.Tests.DayOfWeek;

public sealed record DayOfWeekChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IDayOfWeek valueOnTrue = new Monday();
        IDayOfWeek valueOnFalse = new Tuesday();
        IDayOfWeek choice = new DayOfWeekChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(
            valueOnTrue.DayNumberValue.NumberValue,
            choice.DayNumberValue.NumberValue
        );
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IDayOfWeek valueOnTrue = new Monday();
        IDayOfWeek valueOnFalse = new Tuesday();
        IDayOfWeek choice = new DayOfWeekChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(
            valueOnFalse.DayNumberValue.NumberValue,
            choice.DayNumberValue.NumberValue
        );
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new DayOfWeekChoice(new True(), new Monday(), new Tuesday()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new DayOfWeekChoice(new False(), new Monday(), new Tuesday()).ToString()
        );
    }
}
