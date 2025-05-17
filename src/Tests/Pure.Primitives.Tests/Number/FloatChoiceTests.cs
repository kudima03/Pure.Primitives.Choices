using Pure.Primitives.Bool;
using Pure.Primitives.Number;

namespace Pure.Primitives.Tests.Number;

public sealed record FloatChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IFloat valueOnTrue = new Float(1.03F);
        IFloat valueOnFalse = new Float(1.04F);
        IFloat choice = new FloatChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnTrue.Value, choice.Value);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IFloat valueOnTrue = new Float(1.03F);
        IFloat valueOnFalse = new Float(1.04F);
        IFloat choice = new FloatChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnFalse.Value, choice.Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new FloatChoice(new True(), new Float(1.1F), new Float(1.3F)).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new FloatChoice(new False(), new Float(1.1F), new Float(1.3F)).ToString());
    }
}