using AwesomeAssertions;
using PassGen;
using Serilog;
using Xunit.Abstractions;

namespace Tests;

public class PasswordGeneratorTests
{
    private readonly ILogger _output;

    public PasswordGeneratorTests(ITestOutputHelper helper)
    {
        _output = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.TestOutput(helper)
            .CreateLogger()
            .ForContext<PasswordGeneratorTests>();
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
    [InlineData(5, 5, 128)]
    public void PasswordGeneratedSuccessfully(byte numbers, byte symbols, byte passwordLength)
    {
        var password = PasswordGenerator.GeneratePassword(numbers, symbols, passwordLength);
        _output.Information("Generated password {Password}", password);
        password.Length.Should().Be(passwordLength);
    }

    [Theory]
    [InlineData(0, 0, 10)]
    [InlineData(1, 0, 10)]
    [InlineData(0, 1, 10)]
    [InlineData(5, 5, 50)]
    [InlineData(5, 5, 128)]
    public void HumanReadablePasswordsAreRespected(byte numbers, byte symbols, byte passwordLength)
    {
        var password = PasswordGenerator.GeneratePassword(numbers, symbols, passwordLength, true);
        _output.Information("Generated password {Password}", password);
        password.Length.Should().Be(passwordLength);
        password.Should().NotContainAny(Constants.AmbiguousCharacterAlphabet);
        password.Should().NotContainAny(Constants.AmbiguousNumericAlphabet);
    }

    [Theory]
    [Repeat(10)]
    public void MemorablePasswordsAreGenerated(int count)
    {
        var password = PasswordGenerator.GenerateMemorablePassword();
        _output.Information("Generated password {Count} : {Password}", count, password);
        password.Length.Should().NotBe(0);
        password.Count(x => x == Constants.MemorablePasswordSeparator).Should()
            .Be(Constants.MemorableWordCount - 1);
    }
}