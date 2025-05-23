﻿using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Bool;

namespace Pure.Primitives.Tests.Bool;

public sealed record BoolChoiceTests
{
    [Fact]
    public void CorrectChooseOnTrueCondition()
    {
        IBool choice = new BoolChoice(new True(), new True(), new False());
        Assert.True(choice.Value);
    }

    [Fact]
    public void CorrectChooseOnFalseCondition()
    {
        IBool choice = new BoolChoice(new False(), new True(), new False());
        Assert.False(choice.Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new BoolChoice(new False(), new True(), new False()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new BoolChoice(new True(), new False(), new False()).ToString());
    }
}