using AwesomeAssertions;

namespace CalculatorTests;

public class CalculatorV2IntTests
{
    private readonly Calculator.V2.Calculator<int> _calc;

    public CalculatorV2IntTests()
    {
        _calc = new Calculator.V2.Calculator<int>();
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 2)]
    [InlineData(-1, -1, -2)]
    [InlineData(3, 1, 4)]
    public void AddTests(int first, int second, int result)
    {
        _calc.Add(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 0)]
    [InlineData(-1, -1, 0)]
    [InlineData(3, -1, 4)]
    public void SubtractTests(int first, int second, int result)
    {
        _calc.Subtract(first, second).Should().Be(result);
    }


    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(3, -1, -3)]
    public void MultiplyTests(int first, int second, int result)
    {
        _calc.Multiply(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(3, -1, -3)]
    public void DivideTests(int first, int second, int result)
    {
        _calc.Divide(first, second).Should().Be(result);
    }
}