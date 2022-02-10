# AutoFixture and AutoMoq to reduce unit test plumbing 

## What?

###AutoFixture
[Github](https://github.com/AutoFixture/AutoFixture)

Auto-generates pseudorandom test data we can use for testing. Supports both XUnit and NUnit and has a rich feature-set to customise your data.

###AutoMoq
AutoFixture extension that auto-generates mocks for our interfaces and passes them on to AutoFixture. It can also auto-setup those mocks to all methods will return AutoFixture generated values.

## Why?

- More self-contained and readable unit tests. Each test method is independent from the rest (except for any common customisations) and anything it needs to arrange is visible in the method signature.
- Low-effort plumbing to write and maintain unit tests. Very resilient to refactoring (no need to change a 100 tests after passing an `ILogger` to your class constructor).
- When used with discipline it can help decouple tests from concrete implementations of SUT dependencies. Tests focus on the unit.  