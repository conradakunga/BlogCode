using Serilog;

namespace Mailer;

public sealed class FakeOffice365AlertSender : IOffice365AlertSender
{
    private readonly string _key;
    public string Configuration { get; }

    public FakeOffice365AlertSender(string key)
    {
        _key = key;
        Configuration = $"Configuration - Key: {_key}";
    }

    public Task<string> SendAlert(GeneralAlert message)
    {
        Log.Information("FAKE Office 365 sending alert - {Title} : {Body}", message.Title, message.Message);
        return Task.FromResult(Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee").ToString());
    }
}