# Changelog

All notable changes to Pure.Primitives.Choices are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [1.2.2] — 2026-05-20

- Maintenance release: dependency and build updates.

## [1.2.1] — 2026-05-07

- Maintenance release: dependency and build updates.

## [1.2.0] — 2025-12-10

### Changed

- Package now multi-targets `net7.0`, `net8.0`, `net9.0`, and `net10.0`
  (previously `net9.0` only).
- `Pure.Primitives` is referenced normally again; the separate direct
  reference to `Pure.Primitives.Abstractions` was removed.

## [1.1.0] — 2025-11-01

### Added

- `BoolChoice.BoolValue`, `CharChoice.CharValue`, `GuidChoice.GuidValue`,
  `NumberChoice<T>.NumberValue`, `DayOfWeekChoice.DayNumberValue`, and
  `StringChoice.TextValue` are now public properties instead of explicit
  interface implementations.

### Changed

- **Breaking:** `StringChoice.ValueInternal` renamed to `TextValue`.

## [1.0.0] — 2025-11-01

### Added

- `DateTimeChoice.Nanosecond` and `TimeChoice.Nanosecond`
  (`INumber<ushort>`).

### Changed

- Package now declares `IsAotCompatible` for Native AOT consumers.
- `Pure.Primitives` became a private (build-only) dependency, with
  `Pure.Primitives.Abstractions` referenced directly instead.
- **Breaking:** `DayOfWeekChoice`'s explicit `IDayOfWeek.DayNumberValue`
  implementation changed from `INumber<int>` to `INumber<ushort>`.

## [0.3.0] — 2025-05-28

### Added

- **`DateChoice`** — chooses between two `IDate` values.
- **`TimeChoice`** — chooses between two `ITime` values.
- **`DateTimeChoice`** — chooses between two `IDateTime` values.

### Changed

- **Breaking:** explicit interface members renamed to match the updated
  primitive abstractions: `IBool.Value` → `IBool.BoolValue`,
  `IChar.Value` → `IChar.CharValue`, `IGuid.Value` → `IGuid.GuidValue`,
  `INumber<T>.Value` → `INumber<T>.NumberValue`,
  `IDayOfWeek.DayNumber` → `IDayOfWeek.DayNumberValue`, and
  `IString.Value` → `IString.TextValue` on `BoolChoice`, `CharChoice`,
  `GuidChoice`, `NumberChoice<T>`, `DayOfWeekChoice`, and `StringChoice`.

## [0.2.0] — 2025-05-26

### Added

- **`StringChoice`** now implements `IEnumerable<IChar>`, enumerating the
  chosen string's characters.

## [0.1.0] — 2025-05-23

### Added

- **`BoolChoice`** — chooses between two `IBool` values.
- **`CharChoice`** — chooses between two `IChar` values.
- **`GuidChoice`** — chooses between two `IGuid` values.
- **`NumberChoice<T>`** — chooses between two `INumber<T>` values for any
  `System.Numerics.INumber<T>`.
- **`StringChoice`** — chooses between two `IString` values.
- **`DayOfWeekChoice`** — chooses between two `IDayOfWeek` values.

Each `*Choice` type selects one of two supplied values based on an
`IBool` condition.
