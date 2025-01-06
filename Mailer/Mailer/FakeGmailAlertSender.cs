using Serilog;

namespace Mailer;

public sealed class FakeGmailAlertSender : IGmailAlertSender
{
    private readonly int _port;
    private readonly string _username;
    private readonly string _password;
    public string Configuration { get; }

    public FakeGmailAlertSender(int port, string username, string password)
    {
        _port = port;
        _username = username;
        _password = password;
        Configuration = $"FAKE - Configuration - Port: {_port}; Username: {_username}; Password: {_password}";
    }

    public Task<string> SendAlert(GeneralAlert message)
    {
        Log.Information("FAKE Gmail sending alert - {Title} : {Body}", message.Title, message.Message);
        return Task.FromResult(Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff").ToString());
    }
}