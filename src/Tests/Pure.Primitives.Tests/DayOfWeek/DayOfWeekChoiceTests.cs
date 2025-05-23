﻿using Pure.Primitives.Bool;
using Pure.Primitives.DayOfWeek;

namespace Pure.Primitives.Tests.DayOfWeek;

public sealed record DayOfWeekChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IDayOfWeek valueOnTrue = new Monday();
        IDayOfWeek valueOnFalse = new Tuesday();
        IDayOfWeek choice = new DayOfWeekChoice(new True(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnTrue.DayNumber.Value, choice.DayNumber.Value);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IDayOfWeek valueOnTrue = new Monday();
        IDayOfWeek valueOnFalse = new Tuesday();
        IDayOfWeek choice = new DayOfWeekChoice(new False(), valueOnTrue, valueOnFalse);
        Assert.Equal(valueOnFalse.DayNumber.Value, choice.DayNumber.Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new DayOfWeekChoice(new True(), new Monday(), new Tuesday()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new DayOfWeekChoice(new False(), new Monday(), new Tuesday()).ToString());
    }
}