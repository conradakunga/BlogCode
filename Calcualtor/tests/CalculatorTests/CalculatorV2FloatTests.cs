using AwesomeAssertions;

namespace CalculatorTests;

public class CalculatorV2FloatTests
{
    private readonly Calculator.V2.Calculator<float> _calc;

    public CalculatorV2FloatTests()
    {
        _calc = new Calculator.V2.Calculator<float>();
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 2)]
    [InlineData(-1, -1, -2)]
    [InlineData(3, 1, 4)]
    public void AddTests(float first, float second, float result)
    {
        _calc.Add(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 0)]
    [InlineData(-1, -1, 0)]
    [InlineData(3, -1, 4)]
    public void SubtractTests(float first, float second, float result)
    {
        _calc.Subtract(first, second).Should().Be(result);
    }


    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(3, -1, -3)]
    public void MultiplyTests(float first, float second, float result)
    {
        _calc.Multiply(first, second).Should().Be(result);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(-1, -1, 1)]
    [InlineData(3, -1, -3)]
    public void DivideTests(float first, float second, float result)
    {
        _calc.Divide(first, second).Should().Be(result);
    }
}