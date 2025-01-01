namespace Mailer;

public sealed class Office365AlertSender : IAlertSender
{
    private readonly string _key;
    public string Configuration { get; }

    public Office365AlertSender(string key)
    {
        _key = key;
        Configuration = $"Configuration - Key: {_key}";
    }

    public async Task<string> SendAlert(Office365Alert message)
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        return Guid.NewGuid().ToString();
    }

    // New method that sends a generic GeneralAlert
    public async Task<string> SendAlert(GeneralAlert message)
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        return Guid.NewGuid().ToString();
    }
}