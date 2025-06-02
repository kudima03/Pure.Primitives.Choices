using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Char;
using Pure.Primitives.Abstractions.String;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.String;
using Pure.Primitives.String;
using Randomizer.Interfaces.ReferenceTypes;
using Randomizer.Types;
using System.Collections;

namespace Pure.Primitives.Choices.Tests.String;

using String = Primitives.String.String;

public sealed record StringChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IRandomString randomString = new RandomStringGenerator();

        IEnumerable<IString> valuesOnTrue =
            Enumerable.Range(0, 1000)
                .Select(_ => new String(randomString.GenerateValue()))
                .ToArray();

        IEnumerable<IString> valuesOnFalse =
            Enumerable.Range(0, 1000)
                .Select(_ => new String(randomString.GenerateValue()))
                .ToArray();

        IBool condition = new True();

        IEnumerable<IString> choices = valuesOnTrue.Zip(valuesOnFalse,
            (trueValue, falseValue) => new StringChoice(condition, trueValue, falseValue));

        Assert.Equal(valuesOnTrue, choices, (valueOnTrue, choice) => valueOnTrue.TextValue == choice.TextValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IRandomString randomString = new RandomStringGenerator();

        IEnumerable<IString> valuesOnTrue =
            Enumerable.Range(0, 1000)
                .Select(_ => new String(randomString.GenerateValue()))
                .ToArray();

        IEnumerable<IString> valuesOnFalse =
            Enumerable.Range(0, 1000)
                .Select(_ => new String(randomString.GenerateValue()))
                .ToArray();

        IBool condition = new False();

        IEnumerable<IString> choices = valuesOnTrue.Zip(valuesOnFalse,
            (trueValue, falseValue) => new StringChoice(condition, trueValue, falseValue));

        Assert.Equal(valuesOnFalse, choices, (valueOnTrue, choice) => valueOnTrue.TextValue == choice.TextValue);
    }


    [Fact]
    public void EnumeratesAsTyped()
    {
        IRandomString randomString = new RandomStringGenerator();

        IString valueOnTrue = new String(randomString.GenerateValue());
        IString valueOnFalse = new String(randomString.GenerateValue());
        IString choice = new StringChoice(new False(), valueOnTrue, valueOnFalse);

        Assert.True(valueOnFalse.Select(x => x.CharValue).SequenceEqual(choice.Select(x => x.CharValue)));
    }

    [Fact]
    public void EnumeratesAsUntyped()
    {
        IRandomString randomString = new RandomStringGenerator();

        IString valueOnTrue = new String(randomString.GenerateValue());
        IString valueOnFalse = new String(randomString.GenerateValue());
        IEnumerable choice = new StringChoice(new False(), valueOnTrue, valueOnFalse);

        ICollection<IChar> symbols = new List<IChar>();

        foreach (object symbol in choice)
        {
            symbols.Add((symbol as IChar)!);
        }

        Assert.True(valueOnFalse.Select(x => x.CharValue).SequenceEqual(symbols.Select(x => x.CharValue)));
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new StringChoice(new True(), new EmptyString(), new EmptyString()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new StringChoice(new False(), new EmptyString(), new EmptyString()).ToString());
    }
}