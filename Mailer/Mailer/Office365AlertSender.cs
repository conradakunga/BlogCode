namespace Mailer;

public sealed class Office365AlertSender
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
}