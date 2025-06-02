using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.DateTime;
using Randomizer;
using Randomizer.Interfaces.ValueTypes;

namespace Pure.Primitives.Choices.Tests.DateTime;

using Date = Primitives.Date.Date;
using DateTime = Primitives.DateTime.DateTime;
using Time = Primitives.Time.Time;

public sealed record DateTimeChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        Random random = new Random();
        IRandomDateTime dateTimeGenerator = new RandomDateTimeGenerator();

        IEnumerable<IDateTime> trueValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue().AddTicks(random.NextInt64(0, 1000)))
            .Select(x => (date: DateOnly.FromDateTime(x), time: TimeOnly.FromDateTime(x)))
            .Select(x => new DateTime(new Date(x.date), new Time(x.time)))
            .ToArray();

        IEnumerable<IDateTime> falseValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue().AddTicks(random.NextInt64(0, 1000)))
            .Select(x => (date: DateOnly.FromDateTime(x), time: TimeOnly.FromDateTime(x)))
            .Select(x => new DateTime(new Date(x.date), new Time(x.time)))
            .ToArray();

        IBool condition = new True();

        IEnumerable<IDateTime> choices = trueValues.Zip(falseValues,
            (trueValue, falseValue) => new DateTimeChoice(condition, trueValue, falseValue));

        Assert.Equal(trueValues, choices, (choice, dateTime) =>
            choice.Year.NumberValue == dateTime.Year.NumberValue &&
            choice.Month.NumberValue == dateTime.Month.NumberValue &&
            choice.Day.NumberValue == dateTime.Day.NumberValue &&
            choice.Hour.NumberValue == dateTime.Hour.NumberValue &&
            choice.Minute.NumberValue == dateTime.Minute.NumberValue &&
            choice.Second.NumberValue == dateTime.Second.NumberValue &&
            choice.Millisecond.NumberValue == dateTime.Millisecond.NumberValue &&
            choice.Microsecond.NumberValue == dateTime.Microsecond.NumberValue &&
            choice.Nanoseconds.NumberValue == dateTime.Nanoseconds.NumberValue);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        Random random = new Random();
        IRandomDateTime dateTimeGenerator = new RandomDateTimeGenerator();

        IEnumerable<IDateTime> trueValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue().AddTicks(random.NextInt64(0, 1000)))
            .Select(x => (date: DateOnly.FromDateTime(x), time: TimeOnly.FromDateTime(x)))
            .Select(x => new DateTime(new Date(x.date), new Time(x.time)))
            .ToArray();

        IEnumerable<IDateTime> falseValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue().AddTicks(random.NextInt64(0, 1000)))
            .Select(x => (date: DateOnly.FromDateTime(x), time: TimeOnly.FromDateTime(x)))
            .Select(x => new DateTime(new Date(x.date), new Time(x.time)))
            .ToArray();

        IBool condition = new False();

        IEnumerable<IDateTime> choices = trueValues.Zip(falseValues,
            (trueValue, falseValue) => new DateTimeChoice(condition, trueValue, falseValue));

        Assert.Equal(falseValues, choices, (choice, dateTime) =>
            choice.Year.NumberValue == dateTime.Year.NumberValue &&
            choice.Month.NumberValue == dateTime.Month.NumberValue &&
            choice.Day.NumberValue == dateTime.Day.NumberValue &&
            choice.Hour.NumberValue == dateTime.Hour.NumberValue &&
            choice.Minute.NumberValue == dateTime.Minute.NumberValue &&
            choice.Second.NumberValue == dateTime.Second.NumberValue &&
            choice.Millisecond.NumberValue == dateTime.Millisecond.NumberValue &&
            choice.Microsecond.NumberValue == dateTime.Microsecond.NumberValue &&
            choice.Nanoseconds.NumberValue == dateTime.Nanoseconds.NumberValue);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() =>
            new DateTimeChoice(new True(), new DateTime(new Date(new DateOnly(2024, 11, 5)), new Time(new TimeOnly(1, 2, 3, 4, 5))),
                new DateTime(new Date(new DateOnly(2025, 12, 13)), new Time(new TimeOnly(6, 5, 4, 3, 2)))).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() =>
            new DateTimeChoice(new True(), new DateTime(new Date(new DateOnly(2024, 11, 5)), new Time(new TimeOnly(1, 2, 3, 4, 5))),
                new DateTime(new Date(new DateOnly(2025, 12, 13)), new Time(new TimeOnly(6, 5, 4, 3, 2)))).ToString());
    }
}