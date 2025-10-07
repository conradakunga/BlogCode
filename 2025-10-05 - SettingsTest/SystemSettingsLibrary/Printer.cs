using Microsoft.Extensions.Options;

namespace SystemSettingsLibrary;

public class Printer
{
    private readonly SystemSettingsLibrary.SystemSettings _systemSettings;
    public string ForegroundColour => _systemSettings.ForegroundColour;
    public string BackgroundColour => _systemSettings.BackgroundColour;

    public Printer(IOptions<SystemSettingsLibrary.SystemSettings> settings)
    {
        _systemSettings = settings.Value;
    }
}