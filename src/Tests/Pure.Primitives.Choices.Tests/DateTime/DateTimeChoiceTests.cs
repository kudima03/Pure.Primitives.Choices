using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.DateTime;
using Pure.Primitives.Materialized.DateTime;
using Pure.Primitives.Random.DateTime;

namespace Pure.Primitives.Choices.Tests.DateTime;

public sealed record DateTimeChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IDateTime valueOnTrue = new RandomDateTime();
        IDateTime valueOnFalse = new RandomDateTime();
        IDateTime choice = new DateTimeChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(new MaterializedDateTime(valueOnTrue).Value, new MaterializedDateTime(choice).Value);
        Assert.Equal(valueOnTrue.Nanosecond.NumberValue, choice.Nanosecond.NumberValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IDateTime valueOnTrue = new RandomDateTime();
        IDateTime valueOnFalse = new RandomDateTime();
        IDateTime choice = new DateTimeChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(new MaterializedDateTime(valueOnFalse).Value, new MaterializedDateTime(choice).Value);
        Assert.Equal(valueOnFalse.Nanosecond.NumberValue, choice.Nanosecond.NumberValue);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() =>
            new DateTimeChoice(new True(), new RandomDateTime(), new RandomDateTime()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() =>
            new DateTimeChoice(new True(), new RandomDateTime(), new RandomDateTime()).ToString());
    }
}