# Pure.Primitives.Choices

Conditional selection types for **Pure** primitives — select between two values based on an `IBool` condition.

[![.NET build & test](https://github.com/kudima03/Pure.Primitives.Choices/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Choices/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Primitives.Choices/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Choices/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Primitives.Choices)](https://www.nuget.org/packages/Pure.Primitives.Choices)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Primitives.Choices` provides a `*Choice` type for every primitive in the Pure ecosystem. Each choice type wraps an `IBool` condition and two candidate values — `WhenTrue` and `WhenFalse` — and resolves to one of them lazily when the underlying value property is accessed.

## Types

| Type | Implements | Selects between |
|------|-----------|-----------------|
| `BoolChoice` | `IBool` | Two `IBool` values |
| `CharChoice` | `IChar` | Two `IChar` values |
| `StringChoice` | `IString` | Two `IString` values |
| `NumberChoice<T>` | `INumber<T>` | Two `INumber<T>` values |
| `GuidChoice` | `IGuid` | Two `IGuid` values |
| `DateChoice` | `IDate` | Two `IDate` values |
| `TimeChoice` | `ITime` | Two `ITime` values |
| `DateTimeChoice` | `IDateTime` | Two `IDateTime` values |
| `DayOfWeekChoice` | `IDayOfWeek` | Two `IDayOfWeek` values |

All types are `sealed record`s and accept `(IBool condition, T whenTrue, T whenFalse)`.

## Design Principles

- **Lazy evaluation** — the condition is evaluated only when the value property is accessed.
- **Composable** — any `IBool` expression and any compatible Pure primitive can be nested inside a choice.
- **AOT-compatible** — no reflection; fully compatible with Native AOT.

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions) — Pure primitive interfaces
