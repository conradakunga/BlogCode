using AwesomeAssertions;

namespace CalculatorTests;

public class CalculatorV1Tests
{
    private readonly Calculator.V1.Calculator _calc;

    public CalculatorV1Tests()
    {
        _calc = new Calculator.V1.Calculator();
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 2)]
    [InlineData(-1, -1, -2)]
    [InlineData(3, 1, 4)]
    public void AddDecimalTests(decimal first, decimal second, decimal result)
    {
        _calc.Add(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 2)]
    [InlineData(-1, -1, -2)]
    [InlineData(3, 1, 4)]
    public void AddIntTests(int first, int second, int result)
    {
        _calc.Add(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 0)]
    [InlineData(-1, -1, 0)]
    [InlineData(3, -1, 4)]
    public void SubtractIntTests(int first, int second, int result)
    {
        _calc.Subtract(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 0)]
    [InlineData(-1, -1, 0)]
    [InlineData(3, -1, 4)]
    public void SubtractDecimalTests(decimal first, decimal second, decimal result)
    {
        _calc.Subtract(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(3, -1, -3)]
    public void MultiplyDecimalTests(decimal first, decimal second, decimal result)
    {
        _calc.Multiply(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(3, -1, -3)]
    public void MultiplyIntTests(int first, int second, int result)
    {
        _calc.Multiply(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(3, -1, -3)]
    public void DivideIntTests(int first, int second, int result)
    {
        _calc.Divide(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(3, -1, -3)]
    public void DivideDecimalTests(decimal first, decimal second, decimal result)
    {
        _calc.Divide(first, second).Should().Be(result);
    }
}