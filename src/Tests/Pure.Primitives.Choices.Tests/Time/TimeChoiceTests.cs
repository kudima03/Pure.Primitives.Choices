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
        ITime valueOnTrue = new Time(new TimeOnly(1, 2, 3, 4, 5));
        ITime valueOnFalse = new Time(new TimeOnly(6, 5, 4, 3, 2));
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
        ITime valueOnTrue = new Time(new TimeOnly(1, 2, 3, 4, 5));
        ITime valueOnFalse = new Time(new TimeOnly(6, 5, 4, 3, 2));
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