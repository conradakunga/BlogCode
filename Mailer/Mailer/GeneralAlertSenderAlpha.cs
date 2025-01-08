namespace Mailer;

public class GeneralAlertSenderAlpha
{
    private readonly IAlertSender _alertSender;

    public GeneralAlertSenderAlpha(IAlertSender alertSender)
    {
        _alertSender = alertSender;
    }

    public async Task<string> SendAlert(string title, string message)
    {
        return await _alertSender.SendAlert(new GeneralAlert(title, message));
    }
}

public class GeneralAlertSenderBeta
{
    public IAlertSender? AlertSender { get; set; }

    public async Task<string> SendAlert(string title, string message)
    {
        if (AlertSender is null)
            throw new Exception("AlertSender is mandatory!");
        return await AlertSender!.SendAlert(new GeneralAlert(title, message));
    }
}

public class GeneralAlertSenderCharlie
{
    public async Task<string> SendAlert(IAlertSender alertSender, string title, string message)
    {
        return await alertSender.SendAlert(new GeneralAlert(title, message));
    }
}