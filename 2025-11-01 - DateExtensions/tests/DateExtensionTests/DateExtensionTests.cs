using AwesomeAssertions;
using DateExtensions;

namespace DateExtensionTests;

public class DateExtensionTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(-1)]
    public void YearTests(int offsetYears)
    {
        var current = DateTime.Now;
        var expected = new DateOnly(current.Year + offsetYears, current.Month, current.Day);
        DateOnly.CreateCurrentWithOffsetYear(offsetYears).Should().Be(expected);
    }
}