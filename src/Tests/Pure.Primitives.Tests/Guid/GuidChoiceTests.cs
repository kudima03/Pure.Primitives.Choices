using Pure.Primitives.Bool;
using Pure.Primitives.Guid;

namespace Pure.Primitives.Tests.Guid;

using Guid = Primitives.Guid.Guid;

public sealed record GuidChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IGuid valueOnTrue = new Guid();
        IGuid valueOnFalse = new Guid();
        IGuid choice = new GuidChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnTrue.Value, choice.Value);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IGuid valueOnTrue = new Guid();
        IGuid valueOnFalse = new Guid();
        IGuid choice = new GuidChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnFalse.Value, choice.Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new GuidChoice(new True(), new Guid(), new Guid()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new GuidChoice(new False(), new Guid(), new Guid()).ToString());
    }
}