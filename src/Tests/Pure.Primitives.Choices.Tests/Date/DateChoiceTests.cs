using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Date;

namespace Pure.Primitives.Choices.Tests.Date;

using Date = Primitives.Date.Date;

public sealed record DateChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IDate valueOnTrue = new Date(new DateOnly(2024, 11, 5));
        IDate valueOnFalse = new Date(new DateOnly(2025, 6, 1));
        IDate choice = new DateChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(
            new DateOnly(valueOnTrue.Year.NumberValue, valueOnTrue.Month.NumberValue, valueOnTrue.Day.NumberValue),
            new DateOnly(choice.Year.NumberValue, choice.Month.NumberValue, choice.Day.NumberValue));
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IDate valueOnTrue = new Date(new DateOnly(2024, 11, 5));
        IDate valueOnFalse = new Date(new DateOnly(2025, 6, 1));
        IDate choice = new DateChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(
            new DateOnly(valueOnFalse.Year.NumberValue, valueOnFalse.Month.NumberValue, valueOnFalse.Day.NumberValue),
            new DateOnly(choice.Year.NumberValue, choice.Month.NumberValue, choice.Day.NumberValue));
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() =>
            new DateChoice(new True(), new Date(DateOnly.FromDateTime(System.DateTime.Now)),
                new Date(DateOnly.FromDateTime(System.DateTime.Now))).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new DateChoice(new False(),
                new Date(DateOnly.FromDateTime(System.DateTime.Now)),
                new Date(DateOnly.FromDateTime(System.DateTime.Now)))
            .ToString());
    }
}