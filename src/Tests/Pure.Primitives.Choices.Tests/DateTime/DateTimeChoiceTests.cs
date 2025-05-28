using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Time;

namespace Pure.Primitives.Choices.Tests.DateTime;

using DateTime = Primitives.DateTime.DateTime;
using Date = Primitives.Date.Date;
using Time = Primitives.Time.Time;

public sealed record DateTimeChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IDateTime valueOnTrue = new DateTime(new Date(new DateOnly(2024, 11, 5)), new Time(new TimeOnly(1, 2, 3, 4, 5)));
        IDateTime valueOnFalse = new DateTime(new Date(new DateOnly(2025, 12, 13)), new Time(new TimeOnly(6, 5, 4, 3, 2)));
        IDateTime choice = new DateTimeChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(
            new System.DateTime(
                new DateOnly(valueOnTrue.Year.NumberValue,
                    valueOnTrue.Month.NumberValue,
                    valueOnTrue.Day.NumberValue),
                new TimeOnly(valueOnTrue.Hour.NumberValue,
                    valueOnTrue.Minute.NumberValue,
                    valueOnTrue.Second.NumberValue,
                    valueOnTrue.Millisecond.NumberValue,
                    valueOnTrue.Microsecond.NumberValue)),
            new System.DateTime(
                new DateOnly(choice.Year.NumberValue,
                    choice.Month.NumberValue,
                    choice.Day.NumberValue),
                new TimeOnly(choice.Hour.NumberValue,
                    choice.Minute.NumberValue,
                    choice.Second.NumberValue,
                    choice.Millisecond.NumberValue,
                    choice.Microsecond.NumberValue)));
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IDateTime valueOnTrue = new DateTime(new Date(new DateOnly(2024, 11, 5)), new Time(new TimeOnly(1, 2, 3, 4, 5)));
        IDateTime valueOnFalse = new DateTime(new Date(new DateOnly(2025, 12, 13)), new Time(new TimeOnly(6, 5, 4, 3, 2)));
        IDateTime choice = new DateTimeChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(
            new System.DateTime(
                new DateOnly(valueOnFalse.Year.NumberValue,
                    valueOnFalse.Month.NumberValue,
                    valueOnFalse.Day.NumberValue),
                new TimeOnly(valueOnFalse.Hour.NumberValue,
                    valueOnFalse.Minute.NumberValue,
                    valueOnFalse.Second.NumberValue,
                    valueOnFalse.Millisecond.NumberValue,
                    valueOnFalse.Microsecond.NumberValue)),
            new System.DateTime(
                new DateOnly(choice.Year.NumberValue,
                    choice.Month.NumberValue,
                    choice.Day.NumberValue),
                new TimeOnly(choice.Hour.NumberValue,
                    choice.Minute.NumberValue,
                    choice.Second.NumberValue,
                    choice.Millisecond.NumberValue,
                    choice.Microsecond.NumberValue)));
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() =>
            new DateTimeChoice(new True(), new DateTime(new Date(new DateOnly(2024, 11, 5)), new Time(new TimeOnly(1, 2, 3, 4, 5))),
                new DateTime(new Date(new DateOnly(2025, 12, 13)), new Time(new TimeOnly(6, 5, 4, 3, 2)))).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() =>
            new DateTimeChoice(new True(), new DateTime(new Date(new DateOnly(2024, 11, 5)), new Time(new TimeOnly(1, 2, 3, 4, 5))),
                new DateTime(new Date(new DateOnly(2025, 12, 13)), new Time(new TimeOnly(6, 5, 4, 3, 2)))).ToString());
    }
}