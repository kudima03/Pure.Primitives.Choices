using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Time;
using Pure.Primitives.Materialized.Time;
using Pure.Primitives.Random.Time;

namespace Pure.Primitives.Choices.Tests.Time;

public sealed record TimeChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        ITime valueOnTrue = new RandomTime();
        ITime valueOnFalse = new RandomTime();
        ITime choice = new TimeChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(new MaterializedTime(valueOnTrue).Value, new MaterializedTime(choice).Value);
        Assert.Equal(valueOnTrue.Nanosecond.NumberValue, choice.Nanosecond.NumberValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        ITime valueOnTrue = new RandomTime();
        ITime valueOnFalse = new RandomTime();
        ITime choice = new TimeChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(new MaterializedTime(valueOnFalse).Value, new MaterializedTime(choice).Value);
        Assert.Equal(valueOnFalse.Nanosecond.NumberValue, choice.Nanosecond.NumberValue);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new TimeChoice(new True(), new RandomTime(), new RandomTime()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new TimeChoice(new True(), new RandomTime(), new RandomTime()).ToString());
    }
}