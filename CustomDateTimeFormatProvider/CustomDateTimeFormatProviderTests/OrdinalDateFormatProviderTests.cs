using System.Globalization;
using AwesomeAssertions;
using CustomDateTimeFormatProvider;

namespace CustomDateTimeFormatProviderTests;

public class OrdinalDateFormatProviderTests
{
    [Theory]
    [InlineData(1, "do MMM yyyy", "1st Jan 2025")]
    [InlineData(1, "MMM do yyyy", "Jan 1st 2025")]
    [InlineData(1, "yyyy MMM do", "2025 Jan 1st")]
    [InlineData(1, "ddo MMM yyyy", "01st Jan 2025")]
    public void FormatStringTest(int day, string formatString, string ordinal)
    {
        var date = new DateOnly(2025, 1, day);
        var result = string.Format(new OrdinalDateFormatProvider(),
            $"{{0:{formatString}}}", date);
        result.Should().Be(ordinal);
    }

    [Theory]
    [InlineData(1, "do MMM yyyy", "1st Jan 2025", "en-US")]
    [InlineData(1, "ddo MMM yyyy", "01st Jan 2025", "en-US")]
    public void CultureTest(int day, string formatString, string ordinal, string culture)
    {
        var date = new DateOnly(2025, 1, day);
        var result = string.Format(new OrdinalDateFormatProvider(new CultureInfo(culture)),
            $"{{0:{formatString}}}",
            date);
        result.Should().Be(ordinal);
    }
}