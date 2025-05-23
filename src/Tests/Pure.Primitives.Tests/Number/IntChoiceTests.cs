using Pure.Primitives.Bool;
using Pure.Primitives.Number;

namespace Pure.Primitives.Tests.Number;

public sealed record IntChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IInt valueOnTrue = new Int(1);
        IInt valueOnFalse = new Int(0);
        IInt choice = new IntChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnTrue.Value, choice.Value);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IInt valueOnTrue = new Int(1);
        IInt valueOnFalse = new Int(0);
        IInt choice = new IntChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnFalse.Value, choice.Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new IntChoice(new True(), new Int(1), new Int(0)).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new IntChoice(new False(), new Int(1), new Int(0)).ToString());
    }
}