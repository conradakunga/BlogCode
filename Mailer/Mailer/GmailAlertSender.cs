namespace Mailer;

public sealed class GmailAlertSender : IAlertSender
{
    private readonly int _port;
    private readonly string _username;
    private readonly string _password;
    public string Configuration { get; }

    public GmailAlertSender(int port, string username, string password)
    {
        _port = port;
        _username = username;
        _password = password;
        Configuration = $"Configuration - Port: {_port}; Username: {_username}; Password: {_password}";
    }

    public async Task<string> SendAlert(GmailAlert message)
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