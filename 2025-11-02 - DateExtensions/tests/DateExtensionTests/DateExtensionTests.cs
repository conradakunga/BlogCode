using System.Globalization;
using AwesomeAssertions;
using DateExtensions;

namespace DateExtensionTests;

public class DateExtensionTests
{
    [Fact]
    public void CultureName_Is_Returned_Correctly()
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-KE");
        DateOnly.CalendarName.Should().Be("Gregorian calendar");
    }
}