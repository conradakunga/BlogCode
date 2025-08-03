using AwesomeAssertions;
using Generator;
using Xunit.Abstractions;

namespace RandomStringGeneratorTests;

public class SecureRandomStringGeneratorTests
{
    private readonly ITestOutputHelper _output;

    public SecureRandomStringGeneratorTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void InvalidLengthsRejected(int length)
    {
        var ex = Record.Exception(() => SecureRandomStringGenerator.GenerateRandomString(length));
        ex.Should().BeOfType<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(20)]
    [InlineData(50)]
    public void StringsAreGeneratedCorrectly(int length)
    {
        var randomString = SecureRandomStringGenerator.GenerateRandomString(length);
        randomString.Length.Should().Be(length);
        _output.WriteLine($"Generated string: {randomString} of length {length}");

        Constants.Alphabet.ToCharArray().Should().Contain(randomString);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(20)]
    [InlineData(50)]
    public void StringsAreGeneratedCorrectly2(int length)
    {
        var randomString = SecureRandomStringGenerator.GenerateRandomString2(length);
        randomString.Length.Should().Be(length);
        _output.WriteLine($"Generated string: {randomString} of length {length}");

        Constants.Alphabet.ToCharArray().Should().Contain(randomString);
    }
}