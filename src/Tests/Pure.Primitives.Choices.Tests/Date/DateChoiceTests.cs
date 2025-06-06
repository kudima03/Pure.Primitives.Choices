using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Date;
using Pure.Primitives.Date;
using Pure.Primitives.Random.Date;

namespace Pure.Primitives.Choices.Tests.Date;

public sealed record DateChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IDate valueOnTrue = new RandomDate();
        IDate valueOnFalse = new RandomDate();
        IDate choice = new DateChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(new MaterializedDate(valueOnTrue).Value, new MaterializedDate(choice).Value);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IDate valueOnTrue = new RandomDate();
        IDate valueOnFalse = new RandomDate();
        IDate choice = new DateChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(new MaterializedDate(valueOnFalse).Value, new MaterializedDate(choice).Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() =>
            new DateChoice(new True(), new RandomDate(), new RandomDate())).GetHashCode();
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() =>
            new DateChoice(new True(), new RandomDate(), new RandomDate())).ToString();
    }
}