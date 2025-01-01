namespace Mailer;

public interface IAlertSender
{
    public Task<string> SendAlert(GeneralAlert message);
    public string Configuration { get; }
}