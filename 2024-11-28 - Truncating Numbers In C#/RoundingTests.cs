using FluentAssertions;

namespace NumberTruncation;

public class RoundingTests
{
    [Theory]
    [InlineData(123.449, 123.44)]
    [InlineData(123.450, 123.45)]
    [InlineData(123.451, 123.45)]
    [InlineData(123.454, 123.45)]
    [InlineData(123.455, 123.45)]
    [InlineData(123.456, 123.45)]
    [InlineData(123.459, 123.45)]
    [InlineData(123.460, 123.46)]
    public void TruncationIsDoneCorrectly(decimal input, decimal expected)
    {
        Math.Round(input, 2, MidpointRounding.ToZero).Should().Be(expected);
    }
}