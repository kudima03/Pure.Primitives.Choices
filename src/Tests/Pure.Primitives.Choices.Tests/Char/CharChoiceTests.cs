using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Char;
using Randomizer;
using Randomizer.Interfaces.ReferenceTypes;

namespace Pure.Primitives.Choices.Tests.Char;

using Char = Primitives.Char.Char;

public sealed record CharChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IRandomCharacter randomCharacter =  new RandomAlphanumericCharGenerator();

        IEnumerable<IChar> valuesOnTrue =
            Enumerable.Range(0, 1000)
                .Select(_ => new Char(randomCharacter.GenerateValue()))
                .ToArray();

        IEnumerable<IChar> valuesOnFalse =
            Enumerable.Range(0, 1000)
                .Select(_ => new Char(randomCharacter.GenerateValue()))
                .ToArray();

        IBool condition = new True();

        IEnumerable<IChar> choices = valuesOnTrue.Zip(valuesOnFalse,
            (trueValue, falseValue) => new CharChoice(condition, trueValue, falseValue));

        Assert.Equal(valuesOnTrue, choices, (valueOnTrue, choice) => valueOnTrue.CharValue == choice.CharValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IRandomCharacter randomCharacter =  new RandomAlphanumericCharGenerator();

        IEnumerable<IChar> valuesOnTrue =
            Enumerable.Range(0, 1000)
                .Select(_ => new Char(randomCharacter.GenerateValue()))
                .ToArray();

        IEnumerable<IChar> valuesOnFalse =
            Enumerable.Range(0, 1000)
                .Select(_ => new Char(randomCharacter.GenerateValue()))
                .ToArray();

        IBool condition = new False();

        IEnumerable<IChar> choices = valuesOnTrue.Zip(valuesOnFalse,
            (trueValue, falseValue) => new CharChoice(condition, trueValue, falseValue));

        Assert.Equal(valuesOnFalse, choices, (valueOnTrue, choice) => valueOnTrue.CharValue == choice.CharValue);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new CharChoice(new True(), new Char('A'), new Char('B')).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new CharChoice(new False(), new Char('A'), new Char('B')).ToString());
    }
}