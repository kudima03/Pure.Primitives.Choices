using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Time;

namespace Pure.Primitives.Choices.Tests.Time;

using Time = Primitives.Time.Time;

public sealed record TimeChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        System.DateTime dateTimeOnTrue = new System.DateTime(2024, 11, 5, 1, 2, 3, 4, 5).AddTicks(1);
        System.DateTime dateTimeOnFalse = new System.DateTime(2025, 12, 13, 6, 5, 4, 3, 2).AddTicks(2);
        ITime valueOnTrue = new Time(TimeOnly.FromDateTime(dateTimeOnTrue));
        ITime valueOnFalse = new Time(TimeOnly.FromDateTime(dateTimeOnFalse));
        ITime choice = new TimeChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(
            new TimeOnly(valueOnTrue.Hour.NumberValue,
                valueOnTrue.Minute.NumberValue,
                valueOnTrue.Second.NumberValue,
                valueOnTrue.Millisecond.NumberValue,
                valueOnTrue.Microsecond.NumberValue),
            new TimeOnly(choice.Hour.NumberValue,
                choice.Minute.NumberValue,
                choice.Second.NumberValue,
                choice.Millisecond.NumberValue,
                choice.Microsecond.NumberValue));

        Assert.Equal(valueOnTrue.Nanoseconds.NumberValue, choice.Nanoseconds.NumberValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        System.DateTime dateTimeOnTrue = new System.DateTime(2024, 11, 5, 1, 2, 3, 4, 5).AddTicks(1);
        System.DateTime dateTimeOnFalse = new System.DateTime(2025, 12, 13, 6, 5, 4, 3, 2).AddTicks(2);
        ITime valueOnTrue = new Time(TimeOnly.FromDateTime(dateTimeOnTrue));
        ITime valueOnFalse = new Time(TimeOnly.FromDateTime(dateTimeOnFalse));
        ITime choice = new TimeChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(
            new TimeOnly(valueOnFalse.Hour.NumberValue,
                valueOnFalse.Minute.NumberValue,
                valueOnFalse.Second.NumberValue,
                valueOnFalse.Millisecond.NumberValue,
                valueOnFalse.Microsecond.NumberValue),
            new TimeOnly(choice.Hour.NumberValue,
                choice.Minute.NumberValue,
                choice.Second.NumberValue,
                choice.Millisecond.NumberValue,
                choice.Microsecond.NumberValue));

        Assert.Equal(valueOnFalse.Nanoseconds.NumberValue, choice.Nanoseconds.NumberValue);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() =>
            new TimeChoice(new True(), new Time(TimeOnly.FromDateTime(System.DateTime.Now)),
                new Time(TimeOnly.FromDateTime(System.DateTime.Now))).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new TimeChoice(new False(),
                new Time(TimeOnly.FromDateTime(System.DateTime.Now)),
                new Time(TimeOnly.FromDateTime(System.DateTime.Now)))
            .ToString());
    }
}