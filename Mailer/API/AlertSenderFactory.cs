using Mailer;

namespace API;

public class AlertSenderFactory : IAlertSenderFactory
{
    private readonly ServiceProvider _serviceProvider;

    public AlertSenderFactory(ServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IAlertSender CreateAlertSender(AlertSender alertSender)
    {
        throw new NotImplementedException();
    }
}