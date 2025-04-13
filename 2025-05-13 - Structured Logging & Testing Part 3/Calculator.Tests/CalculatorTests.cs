using FluentAssertions;
using Serilog;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Calculator.Tests;

public class CalculatorTests
{
    private readonly TestOutputHelper _output;

    public CalculatorTests(ITestOutputHelper testOutputHelper)
    {
        // Cast the injected testOutputHelper to a concrete type
        _output = (TestOutputHelper)testOutputHelper;
        Log.Logger = new LoggerConfiguration()
            // Add the machine name to the logged properties
            .Enrich.WithMachineName()
            // Add the logged-in username to the logged properties
            .Enrich.WithEnvironmentUserName()
            // Add a custom property
            .Enrich.WithProperty("Codename", "Bond")
            // Wire in the test output helper
            .WriteTo.TestOutput(testOutputHelper)
            // Wire in seq
            .WriteTo.Seq("http://localhost:5341")
            // Indicate we want debug log messages as minimum 
            .MinimumLevel.Debug()
            .CreateLogger();
    }

    [Theory]
    [ClassData(typeof(AdditionTestData))]
    public void Integer_Addition_Is_Correct(int first, int second, int result)
    {
        var calc = new Calculator<int>();
        calc.Add(first, second).Should().Be(result);
        // Validate the logged message
        _output.Output.Should().EndWith($"Adding {first} + {second} for Int32\n");
    }

    [Theory]
    [ClassData(typeof(AdditionTestData))]
    public void Decimal_Addition_Is_Correct(decimal first, decimal second, decimal result)
    {
        var calc = new Calculator<decimal>();
        calc.Add(first, second).Should().Be(result);
        _output.Output.Should().EndWith($"Adding {first} + {second} for Decimal\n");
    }
}