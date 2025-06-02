using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.DateTime;
using Pure.Primitives.Choices.Time;

namespace Pure.Primitives.Choices.Tests.DateTime;

using Date = Primitives.Date.Date;
using DateTime = Primitives.DateTime.DateTime;
using Time = Primitives.Time.Time;

public sealed record DateTimeChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        System.DateTime dateTimeOnTrue = new System.DateTime(2024, 11, 5, 1, 2, 3, 4, 5).AddTicks(1);
        System.DateTime dateTimeOnFalse = new System.DateTime(2025, 12, 13, 6, 5, 4, 3, 2).AddTicks(2);
        IDateTime valueOnTrue = new DateTime(new Date(DateOnly.FromDateTime(dateTimeOnTrue)), new Time(TimeOnly.FromDateTime(dateTimeOnTrue)));
        IDateTime valueOnFalse = new DateTime(new Date(DateOnly.FromDateTime(dateTimeOnFalse)), new Time(TimeOnly.FromDateTime(dateTimeOnFalse)));
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

        Assert.Equal(valueOnTrue.Nanoseconds.NumberValue, choice.Nanoseconds.NumberValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        System.DateTime dateTimeOnTrue = new System.DateTime(2024, 11, 5, 1, 2, 3, 4, 5).AddTicks(1);
        System.DateTime dateTimeOnFalse = new System.DateTime(2025, 12, 13, 6, 5, 4, 3, 2).AddTicks(2);
        IDateTime valueOnTrue = new DateTime(new Date(DateOnly.FromDateTime(dateTimeOnTrue)), new Time(TimeOnly.FromDateTime(dateTimeOnTrue)));
        IDateTime valueOnFalse = new DateTime(new Date(DateOnly.FromDateTime(dateTimeOnFalse)), new Time(TimeOnly.FromDateTime(dateTimeOnFalse)));
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

        Assert.Equal(valueOnFalse.Nanoseconds.NumberValue, choice.Nanoseconds.NumberValue);
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