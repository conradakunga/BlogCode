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
    [InlineData(0)]
    [InlineData(9)]
    public void InvalidLengthThrowsException(byte passwordLength)
    {
        var ex = Record.Exception(() => _ = PasswordGenerator.GeneratePassword(0, 0, passwordLength));
        ex.Should().BeOfType<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(11, 0, 10)]
    [InlineData(0, 11, 10)]
    [InlineData(6, 5, 10)]
    public void SymbolsAndNumbersShouldAlignWithRequestedLength(byte numbers, byte symbols, byte passwordLength)
    {
        var ex = Record.Exception(() => _ = PasswordGenerator.GeneratePassword(numbers, symbols, passwordLength));
        ex.Should().BeOfType<ArgumentException>();
    }

    [Theory]
    [InlineData(0, 0, 10)]
    [InlineData(1, 0, 10)]
    [InlineData(0, 1, 10)]
    [InlineData(5, 5, 50)]
    public void PasswordGeneratedSuccessfully(byte numbers, byte symbols, byte passwordLength)
    {
        var password = PasswordGenerator.GeneratePassword(numbers, symbols, passwordLength);
        _helper.WriteLine(password);
        password.Length.Should().Be(passwordLength);
    }

    [Theory]
    [InlineData(0, 0, 10)]
    [InlineData(1, 0, 10)]
    [InlineData(0, 1, 10)]
    [InlineData(5, 5, 50)]
    public void HumanReadablePasswordsAreRespected(byte numbers, byte symbols, byte passwordLength)
    {
        var password = PasswordGenerator.GeneratePassword(numbers, symbols, passwordLength, true);
        _helper.WriteLine(password);
        password.Length.Should().Be(passwordLength);
        password.Should().NotContainAny(Constants.AmbiguousCharacterAlphabet);
        password.Should().NotContainAny(Constants.AmbiguousNumericAlphabet);
    }
}