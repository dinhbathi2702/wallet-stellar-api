﻿using wallet_stellar_api.Domain.Exceptions;
using wallet_stellar_api.Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace wallet_stellar_api.Domain.UnitTests.ValueObjects;

public class ColourTests
{
    [Test]
    public void ShouldReturnCorrectColourCode()
    {
        var code = "#FFFFFF";

        var colour = Colour.From(code);

        colour.Code.Should().Be(code);
    }

    [Test]
    public void ToStringReturnsCode()
    {
        var colour = Colour.White;

        colour.ToString().Should().Be(colour.Code);
    }

    [Test]
    public void ShouldPerformImplicitConversionToColourCodeString()
    {
        string code = Colour.White;

        code.Should().Be("#FFFFFF");
    }

    [Test]
    public void ShouldPerformExplicitConversionGivenSupportedColourCode()
    {
        var colour = (Colour)"#FFFFFF";

        colour.Should().Be(Colour.White);
    }

    [Test]
    public void ShouldThrowUnsupportedColourExceptionGivenNotSupportedColourCode()
    {
        FluentActions.Invoking(() => Colour.From("##FF33CC"))
            .Should().Throw<UnsupportedColourException>();
    }
}
