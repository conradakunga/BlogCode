namespace Mailer;

public sealed class Office365AlertSender
{
    private string _key;

    public Office365AlertSender(string key)
    {
        _key = key;
    }

    public async Task<string> SendAlert(Office365Alert message)
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        return Guid.NewGuid().ToString();
    }
}