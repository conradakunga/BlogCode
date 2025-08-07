using AwesomeAssertions;
using PassGen;
using Serilog;
using Xunit.Abstractions;

namespace Tests;

public class PasswordGeneratorTests
{
    private readonly ITestOutputHelper _helper;

    public PasswordGeneratorTests(ITestOutputHelper helper)
    {
        _helper = helper;
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.XunitTestOutput(helper)
            .CreateLogger();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void InvalidNumbersThrowsException(int numbers)
    {
        var ex = Record.Exception(() => _ = PasswordGenerator.GeneratePassword(numbers, 0, 10));
        ex.Should().BeOfType<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-2)]
    public void InvalidSymbolsThrowsException(int symbols)
    {
        var ex = Record.Exception(() => _ = PasswordGenerator.GeneratePassword(0, symbols, 10));
        ex.Should().BeOfType<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(9)]
    [InlineData(-1)]
    public void InvalidLengthThrowsException(int symbols)
    {
        var ex = Record.Exception(() => _ = PasswordGenerator.GeneratePassword(0, 0, symbols));
        ex.Should().BeOfType<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(11, 0, 10)]
    [InlineData(0, 11, 10)]
    [InlineData(6, 5, 10)]
    public void SymbolsAndNumbersShouldAlignWithRequestedLength(int numbers, int symbols, int passwordLength)
    {
        var ex = Record.Exception(() => _ = PasswordGenerator.GeneratePassword(numbers, symbols, passwordLength));
        ex.Should().BeOfType<ArgumentException>();
    }

    [Theory]
    [InlineData(0, 0, 10)]
    [InlineData(1, 0, 10)]
    [InlineData(0, 1, 10)]
    [InlineData(5, 5, 50)]
    public void PasswordGeneratedSuccessfully(int numbers, int symbols, int passwordLength)
    {
        var password = PasswordGenerator.GeneratePassword(numbers, symbols, passwordLength);
        _helper.WriteLine(password);
        password.Length.Should().Be(passwordLength);
    }
}