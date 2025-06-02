using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Date;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Date;
using Randomizer;
using Randomizer.Interfaces.ValueTypes;

namespace Pure.Primitives.Choices.Tests.Date;

using Date = Primitives.Date.Date;

public sealed record DateChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IRandomDateTime dateTimeGenerator = new RandomDateTimeGenerator();

        IEnumerable<IDate> trueValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue())
            .Select(x => new Date(DateOnly.FromDateTime(x)))
            .ToArray();

        IEnumerable<IDate> falseValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue())
            .Select(x => new Date(DateOnly.FromDateTime(x)))
            .ToArray();

        IBool condition = new True();

        IEnumerable<IDate> choices = trueValues.Zip(falseValues,
            (trueValue, falseValue) => new DateChoice(condition, trueValue, falseValue));

        Assert.Equal(trueValues, choices, (choice, dateTime) =>
            choice.Year.NumberValue == dateTime.Year.NumberValue &&
            choice.Month.NumberValue == dateTime.Month.NumberValue &&
            choice.Day.NumberValue == dateTime.Day.NumberValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IRandomDateTime dateTimeGenerator = new RandomDateTimeGenerator();

        IEnumerable<IDate> trueValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue())
            .Select(x => new Date(DateOnly.FromDateTime(x)))
            .ToArray();

        IEnumerable<IDate> falseValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue())
            .Select(x => new Date(DateOnly.FromDateTime(x)))
            .ToArray();

        IBool condition = new False();

        IEnumerable<IDate> choices = trueValues.Zip(falseValues,
            (trueValue, falseValue) => new DateChoice(condition, trueValue, falseValue));

        Assert.Equal(falseValues, choices, (choice, dateTime) =>
            choice.Year.NumberValue == dateTime.Year.NumberValue &&
            choice.Month.NumberValue == dateTime.Month.NumberValue &&
            choice.Day.NumberValue == dateTime.Day.NumberValue);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() =>
            new DateChoice(new True(),
                new Date(DateOnly.MinValue),
                new Date(DateOnly.MinValue))
                .GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() =>
            new DateChoice(
                new False(), 
                new Date(DateOnly.MinValue), 
                new Date(DateOnly.MinValue)).ToString());
    }
}