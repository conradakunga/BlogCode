using AwesomeAssertions;
using Microsoft.Extensions.Options;
using SystemSettingsLibrary;

namespace SystemSettingsTests;

public class PrinterTests
{
    [Fact]
    public void Printer_Loads_Correctly()
    {
        // Create the settings
        var settings = new SystemSettings
        {
            ForegroundColour = "Red",
            BackgroundColour = "White"
        };

        // Create the options
        var options = Options.Create(settings);

        // Pass the option where neeed
        var printer = new Printer(options);

        printer.ForegroundColour.Should().Be("Red");
        printer.BackgroundColour.Should().Be("White");
    }
}