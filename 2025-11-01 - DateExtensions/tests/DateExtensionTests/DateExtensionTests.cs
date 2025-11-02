using System.ComponentModel;
using AwesomeAssertions;
using DateExtensions;

namespace DateExtensionTests;

public class DateExtensionTests
{
    [Theory]
    [InlineData(2024, 1, 2025)]
    public void YearTests(int currentYear, int offsetYears, int expectedYear)
    {
        var provider = new FakeDateTimeProvider
        var sut = new DateOnly(currentYear, 1, 1);
        sut.Quarter().Should().Be(quarter);
    }
}