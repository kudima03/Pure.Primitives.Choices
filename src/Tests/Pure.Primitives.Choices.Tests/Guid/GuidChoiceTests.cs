using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Guid;

namespace Pure.Primitives.Choices.Tests.Guid;

using Guid = Primitives.Guid.Guid;

public sealed record GuidChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IGuid valueOnTrue = new Guid();
        IGuid valueOnFalse = new Guid();
        IGuid choice = new GuidChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnTrue.GuidValue, choice.GuidValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IGuid valueOnTrue = new Guid();
        IGuid valueOnFalse = new Guid();
        IGuid choice = new GuidChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnFalse.GuidValue, choice.GuidValue);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new GuidChoice(new True(), new Guid(), new Guid()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new GuidChoice(new False(), new Guid(), new Guid()).ToString()
        );
    }
}
