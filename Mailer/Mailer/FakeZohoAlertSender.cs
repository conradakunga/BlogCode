using Serilog;

namespace Mailer;

public sealed class FakeZohoAlertSender : IZohoAlertSender
{
    private readonly string _organizationID;
    private readonly string _secretKey;
    public string Configuration { get; }

    public FakeZohoAlertSender(string organizationID, string secretKey)
    {
        _organizationID = organizationID;
        _secretKey = secretKey;
        Configuration = $"Configuration - Organization ID: {_organizationID}, secretKey: {_secretKey}";
    }

    public Task<string> SendAlert(GeneralAlert message)
    {
        Log.Information("FAKE Zoho sending alert - {Title} : {Body}", message.Title, message.Message);
        return Task.FromResult(Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF").ToString());
    }
}