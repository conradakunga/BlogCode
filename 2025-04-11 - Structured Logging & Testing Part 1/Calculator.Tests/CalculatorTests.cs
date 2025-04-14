using FluentAssertions;
using Xunit.Abstractions;

namespace Calculator.Tests;

public class CalculatorTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public CalculatorTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [ClassData(typeof(AdditionTestData))]
    public void Integer_Addition_Is_Correct(int first, int second, int result)
    {
        var calc = new Calculator<int>();
        _testOutputHelper.WriteLine($"Adding {first} + {second}");
        calc.Add(first, second).Should().Be(result);
    }

    [Theory]
    [ClassData(typeof(AdditionTestData))]
    public void Decimal_Addition_Is_Correct(decimal first, decimal second, decimal result)
    {
        var calc = new Calculator<decimal>();
        _testOutputHelper.WriteLine($"Adding {first} + {second}");
        calc.Add(first, second).Should().Be(result);
    }
}