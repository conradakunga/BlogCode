using Mailer;

namespace API;

public interface IAlertSenderFactory
{
    public IAlertSender CreateAlertSender(AlertSender alertSender);
}