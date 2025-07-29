using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Serilog;

// Setup logging
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

// MaiMessage property
{
    var mail = new MailMessage();
    mail.From = new MailAddress("operations@MI5.co.uk", "M");
    mail.To.Add(new MailAddress("jbond@MI5.co.uk", "James Bond"));
    mail.Subject = "Happy Birthday";
    mail.Body = """
                <html><body>
                Good afternoon.
                <br>
                Have a <B>happy birthday</B> today!
                <br>
                <br>
                <i>Warmest regards, M<i/>
                </body></html>
                """;

    // Set the body format as HTML
    mail.IsBodyHtml = true;

    // Create SMTPClient
    var smtpClient = new SmtpClient
    {
        Host = "localhost",
        Port = 25,
        Credentials = CredentialCache.DefaultNetworkCredentials
    };

    // Send the email
    try
    {
        Log.Information("Sending email");
        smtpClient.Send(mail);
        Log.Information("Email sent");
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Error sending email");
    }
}
// Alternate view 
{
    var mail = new MailMessage();
    mail.From = new MailAddress("operations@MI5.co.uk", "M");
    mail.To.Add(new MailAddress("jbond@MI5.co.uk", "James Bond"));
    mail.Subject = "Happy Birthday James";
    const string html = """
                        <html><body>
                        Good afternoon.
                        <br>
                        Have a <B>happy birthday</B> today!
                        <br>
                        <br>
                        <i>Warmest regards, M<i/>
                        </body></html>
                        """;

    // AlternateView for HTML
    var htmlView = AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html);

    mail.AlternateViews.Add(htmlView);

    // Create SMTPClient
    var smtpClient = new SmtpClient
    {
        Host = "localhost",
        Port = 25,
        Credentials = CredentialCache.DefaultNetworkCredentials
    };

    // Send the email
    try
    {
        Log.Information("Sending email");
        smtpClient.Send(mail);
        Log.Information("Email sent");
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Error sending email");
    }
}