using AwesomeAssertions;

namespace CalculatorTests;

public class CalculatorV2DecimalTests
{
    private readonly Calculator.V2.Calculator<decimal> _calc;

    public CalculatorV2DecimalTests()
    {
        _calc = new Calculator.V2.Calculator<decimal>();
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 2)]
    [InlineData(-1, -1, -2)]
    [InlineData(3, 1, 4)]
    public void AddTests(decimal first, decimal second, decimal result)
    {
        _calc.Add(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 0)]
    [InlineData(-1, -1, 0)]
    [InlineData(3, -1, 4)]
    public void SubtractTests(decimal first, decimal second, decimal result)
    {
        _calc.Subtract(first, second).Should().Be(result);
    }


    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(3, -1, -3)]
    public void MultiplyTests(decimal first, decimal second, decimal result)
    {
        _calc.Multiply(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(3, -1, -3)]
    public void DivideTests(decimal first, decimal second, decimal result)
    {
        _calc.Divide(first, second).Should().Be(result);
    }
}