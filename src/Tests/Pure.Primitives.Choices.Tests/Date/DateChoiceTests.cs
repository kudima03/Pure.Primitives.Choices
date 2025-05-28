using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Date;
using Pure.Primitives.Choices.Guid;

namespace Pure.Primitives.Choices.Tests.Date;

using Date = Primitives.Date.Date;

public sealed record DateChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        DateOnly today = DateOnly.FromDateTime(System.DateTime.Now);
        DateOnly yesterday = DateOnly.FromDateTime(System.DateTime.Now.AddDays(-1));
        IDate valueOnTrue = new Date(today);
        IDate valueOnFalse = new Date(yesterday);
        IDate choice = new DateChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(today, new DateOnly(choice.Year.NumberValue, choice.Month.NumberValue, choice.Day.NumberValue));
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        DateOnly today = DateOnly.FromDateTime(System.DateTime.Now);
        DateOnly yesterday = DateOnly.FromDateTime(System.DateTime.Now.AddDays(-1));
        IDate valueOnTrue = new Date(today);
        IDate valueOnFalse = new Date(yesterday);
        IDate choice = new DateChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(yesterday,
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