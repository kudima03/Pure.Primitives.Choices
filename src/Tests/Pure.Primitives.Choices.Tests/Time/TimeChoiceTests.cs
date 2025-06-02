using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Time;
using Pure.Primitives.Bool;
using Pure.Primitives.Choices.Time;
using Randomizer;
using Randomizer.Interfaces.ValueTypes;

namespace Pure.Primitives.Choices.Tests.Time;

using Time = Primitives.Time.Time;

public sealed record TimeChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        Random random = new Random();
        IRandomDateTime dateTimeGenerator = new RandomDateTimeGenerator();

        IEnumerable<ITime> trueValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue().AddTicks(random.NextInt64(0, 1000)))
            .Select(x => new Time(TimeOnly.FromDateTime(x)))
            .ToArray();


        IEnumerable<ITime> falseValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue().AddTicks(random.NextInt64(0, 1000)))
            .Select(x => new Time(TimeOnly.FromDateTime(x)))
            .ToArray();

        IBool condition = new True();

        IEnumerable<ITime> choices = trueValues.Zip(falseValues,
            (trueValue, falseValue) => new TimeChoice(condition, trueValue, falseValue));

        Assert.Equal(trueValues, choices, (choice, dateTime) =>
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

        IEnumerable<ITime> trueValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue().AddTicks(random.NextInt64(0, 1000)))
            .Select(x => new Time(TimeOnly.FromDateTime(x)))
            .ToArray();


        IEnumerable<ITime> falseValues = Enumerable.Range(0, 1000)
            .Select(_ => dateTimeGenerator.GenerateValue().AddTicks(random.NextInt64(0, 1000)))
            .Select(x => new Time(TimeOnly.FromDateTime(x)))
            .ToArray();

        IBool condition = new False();

        IEnumerable<ITime> choices = trueValues.Zip(falseValues,
            (trueValue, falseValue) => new TimeChoice(condition, trueValue, falseValue));

        Assert.Equal(falseValues, choices, (choice, dateTime) =>
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
            new TimeChoice(new True(), new Time(TimeOnly.FromDateTime(System.DateTime.Now)),
                new Time(TimeOnly.FromDateTime(System.DateTime.Now))).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new TimeChoice(new False(),
                new Time(TimeOnly.FromDateTime(System.DateTime.Now)),
                new Time(TimeOnly.FromDateTime(System.DateTime.Now)))
            .ToString());
    }
}