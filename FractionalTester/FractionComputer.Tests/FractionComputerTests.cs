using FluentAssertions;
using PercentageComputer.Logic;

namespace PercentageComputer.Tests;

public class FractionComputerTests
{
    [Theory]
    [InlineData(50, 100, .5)]
    [InlineData(20, 100, .20)]
    [InlineData(40, 100, .4)]
    [InlineData(0, 100, 0)]
    [InlineData(200, 100, 2)]
    [InlineData(1, 3, 0.33333)]
    public void FractionIsComputedCorrectly(int numerator, int denominator, decimal fraction)
    {
        var computer = new FractionComputer();
        //Math.Round(computer.Compute(numerator, denominator), 5).Should().Be(fraction);
        computer.Compute(numerator, denominator).Should().BeApproximately(fraction, 0.00001M);
    }
}