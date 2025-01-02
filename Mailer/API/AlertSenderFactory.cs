using Mailer;

namespace API;

public class AlertSenderFactory : IAlertSenderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public AlertSenderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IAlertSender CreateAlertSender(AlertSender alertSender)
    {
        return alertSender switch
        {
            // Retrieve GmailSender from ID
            AlertSender.Gmail => _serviceProvider.GetRequiredService<GmailAlertSender>(),
            // Retrieve Office365 from ID
            AlertSender.Office365 => _serviceProvider.GetRequiredService<Office365AlertSender>(),
            // Retrieve ZohoSender from ID
            AlertSender.Zoho => _serviceProvider.GetRequiredService<ZohoAlertSender>(),
            _ => throw new ArgumentOutOfRangeException(nameof(alertSender), alertSender, null)
        };
    }
}