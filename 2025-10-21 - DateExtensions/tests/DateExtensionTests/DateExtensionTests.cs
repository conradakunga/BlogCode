using System.Runtime.InteropServices.JavaScript;
using AwesomeAssertions;
using DateExtensions;

namespace DateExtensionTests;

public class DateExtensionTests
{
    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(2, 1, 1)]
    [InlineData(3, 1, 1)]
    [InlineData(4, 1, 2)]
    [InlineData(5, 1, 2)]
    [InlineData(6, 1, 2)]
    [InlineData(7, 1, 3)]
    [InlineData(8, 1, 3)]
    [InlineData(9, 1, 3)]
    [InlineData(10, 1, 4)]
    [InlineData(11, 1, 4)]
    [InlineData(12, 1, 4)]
    public void QuarterTests(int month, int day, byte quarter)
    {
        var sut = new DateOnly(2025, month, day);
        sut.Quarter().Should().Be(quarter);
    }

    [Theory]
    [InlineData(1, 1, 1, 1)]
    [InlineData(3, 1, 1, 1)]
    [InlineData(4, 1, 4, 1)]
    [InlineData(6, 1, 4, 1)]
    [InlineData(7, 1, 7, 1)]
    [InlineData(9, 1, 7, 1)]
    [InlineData(10, 1, 10, 1)]
    [InlineData(12, 1, 10, 1)]
    public void StartOfQuarterTests(int testMonth, int testDay, int actualMonth, int actualDay)
    {
        var testDate = new DateOnly(2025, testMonth, testDay);
        testDate.GetStartOfQuarter().Should().Be(new DateOnly(2025, actualMonth, actualDay));
    }

    [Theory]
    [InlineData(1, 1, 3, 31)]
    [InlineData(3, 31, 3, 31)]
    [InlineData(4, 1, 6, 30)]
    [InlineData(6, 30, 6, 30)]
    [InlineData(7, 1, 9, 30)]
    [InlineData(9, 30, 9, 30)]
    [InlineData(10, 1, 12, 31)]
    [InlineData(12, 31, 12, 31)]
    public void EndOfQuarterTests(int testMonth, int testDay, int actualMonth, int actualDay)
    {
        var testDate = new DateOnly(2025, testMonth, testDay);
        testDate.GetEndOfQuarter().Should().Be(new DateOnly(2025, actualMonth, actualDay));
    }
}