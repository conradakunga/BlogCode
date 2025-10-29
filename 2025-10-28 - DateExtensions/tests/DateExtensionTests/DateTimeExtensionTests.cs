using AwesomeAssertions;
using DateExtensions;

namespace DateExtensionTests;

public class DateTimeExtensionTests
{
    [Trait("Quarter", "General")]
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
        var sut = new DateTime(2025, month, day);
        sut.Quarter.Should().Be(quarter);
    }

    [Trait("Quarter", "Start")]
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
        var testDate = new DateTime(2025, testMonth, testDay);
        testDate.StartOfQuarter.Should().Be(new DateTime(2025, actualMonth, actualDay));
    }

    [Trait("Quarter", "End")]
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
        var testDate = new DateTime(2025, testMonth, testDay, 23, 59, 59, 999, 999);
        testDate.EndOfQuarter.Should().Be(new DateTime(2025, actualMonth, actualDay, 23, 59, 59, 999, 999));
    }

    [Trait("Quarter", "End")]
    [Theory]
    [InlineData(2025, 4, 2, 2025, 3, 31)]
    [InlineData(2025, 1, 1, 2024, 12, 31)]
    public void EndOfPreviousQuarterTests(int testYear, int testMonth, int testDay, int actualYear, int actualMonth,
        int actualDay)
    {
        var testDate = new DateTime(testYear, testMonth, testDay, 23, 59, 59, 999, 999);
        testDate.EndOfPreviousQuarter.Should()
            .Be(new DateTime(actualYear, actualMonth, actualDay, 23, 59, 59, 999, 999));
    }

    [Trait("Quarter", "Start")]
    [Theory]
    [InlineData(2025, 4, 2, 2025, 1, 1)]
    [InlineData(2025, 1, 2, 2024, 10, 1)]
    public void StartOfPreviousQuarterTests(int testYear, int testMonth, int testDay, int actualYear, int actualMonth,
        int actualDay)
    {
        var testDate = new DateTime(testYear, testMonth, testDay);
        testDate.StartOfPreviousQuarter.Should().Be(new DateTime(actualYear, actualMonth, actualDay));
    }

    [Trait("Quarter", "Start")]
    [Theory]
    [InlineData(2025, 4, 2, 2025, 7, 1)]
    [InlineData(2025, 12, 31, 2026, 1, 1)]
    public void StartOfNextQuarterTests(int testYear, int testMonth, int testDay, int actualYear, int actualMonth,
        int actualDay)
    {
        var testDate = new DateTime(testYear, testMonth, testDay);
        testDate.StartOfNextQuarter.Should().Be(new DateTime(actualYear, actualMonth, actualDay));
    }

    [Trait("Quarter", "End")]
    [Theory]
    [InlineData(2025, 4, 2, 2025, 9, 30)]
    [InlineData(2025, 12, 31, 2026, 3, 31)]
    public void EndOfNextQuarterTests(int testYear, int testMonth, int testDay, int actualYear, int actualMonth,
        int actualDay)
    {
        var testDate = new DateTime(testYear, testMonth, testDay, 23, 59, 59, 999, 999);
        testDate.EndOfNextQuarter.Should()
            .Be(new DateTime(actualYear, actualMonth, actualDay, 23, 59, 59, 999, 999));
    }

    [Trait("Year", "Start")]
    [Theory]
    [InlineData(2025, 4, 2, 2025, 1, 1)]
    [InlineData(2025, 12, 31, 2025, 1, 1)]
    public void StartOfCurrentYearTests(int testYear, int testMonth, int testDay, int actualYear, int actualMonth,
        int actualDay)
    {
        var testDate = new DateTime(testYear, testMonth, testDay);
        testDate.StartOfCurrentYear.Should().Be(new DateTime(actualYear, actualMonth, actualDay));
    }

    [Trait("Year", "End")]
    [Theory]
    [InlineData(2025, 4, 2, 2025, 12, 31)]
    [InlineData(2025, 12, 31, 2025, 12, 31)]
    public void EndOfCurrentYearTests(int testYear, int testMonth, int testDay, int actualYear, int actualMonth,
        int actualDay)
    {
        var testDate = new DateTime(testYear, testMonth, testDay, 23, 59, 59, 999, 999);
        testDate.EndOfCurrentYear.Should()
            .Be(new DateTime(actualYear, actualMonth, actualDay, 23, 59, 59, 999, 999));
    }

    [Trait("Year", "Start")]
    [Theory]
    [InlineData(2025, 4, 2, 2024, 1, 1)]
    [InlineData(2025, 12, 31, 2024, 1, 1)]
    public void StartOfPreviousYearTests(int testYear, int testMonth, int testDay, int actualYear, int actualMonth,
        int actualDay)
    {
        var testDate = new DateTime(testYear, testMonth, testDay);
        testDate.StartOfPreviousYear.Should().Be(new DateTime(actualYear, actualMonth, actualDay));
    }

    [Trait("Year", "End")]
    [Theory]
    [InlineData(2025, 4, 2, 2024, 12, 31)]
    [InlineData(2025, 12, 31, 2024, 12, 31)]
    public void EndOfPreviousYearTests(int testYear, int testMonth, int testDay, int actualYear, int actualMonth,
        int actualDay)
    {
        var testDate = new DateTime(testYear, testMonth, testDay, 23, 59, 59, 999, 999);
        testDate.EndOfPreviousYear.Should()
            .Be(new DateTime(actualYear, actualMonth, actualDay, 23, 59, 59, 999, 999));
    }

    [Trait("Year", "Start")]
    [Theory]
    [InlineData(2025, 4, 2, 2026, 1, 1)]
    [InlineData(2025, 12, 31, 2026, 1, 1)]
    public void StartOfNextYearTests(int testYear, int testMonth, int testDay, int actualYear, int actualMonth,
        int actualDay)
    {
        var testDate = new DateTime(testYear, testMonth, testDay);
        testDate.StartOfNextYear.Should().Be(new DateTime(actualYear, actualMonth, actualDay));
    }

    [Trait("Year", "End")]
    [Theory]
    [InlineData(2025, 4, 2, 2026, 12, 31)]
    [InlineData(2025, 12, 31, 2026, 12, 31)]
    public void EndOfNextYearTests(int testYear, int testMonth, int testDay, int actualYear, int actualMonth,
        int actualDay)
    {
        var testDate = new DateTime(testYear, testMonth, testDay, 23, 59, 59, 999, 999);
        testDate.EndOfNextYear.Should().Be(new DateTime(actualYear, actualMonth, actualDay, 23, 59, 59, 999, 999));
    }
}