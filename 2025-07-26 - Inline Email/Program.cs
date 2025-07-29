using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Serilog;

// Image from file system
{
    // Setup logging
    Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

    var mail = new MailMessage();
    mail.From = new MailAddress("operations@MI5.co.uk", "M");
    mail.To.Add(new MailAddress("jbond@MI5.co.uk", "James Bond"));
    mail.Subject = "Happy Birthday James";

    // HTML body with image reference to linked resource by ID
    const string htmlBody = """
                            <html><body>
                            Good afternoon.
                            <br>
                            Have a happy birthday today!
                            <br>
                            <br>
                            <img src='cid:Image1' />
                            </body></html>
                            """;

    // AlternateView for HTML with linked image
    var htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);

    // Load image and link it to the HTML view
    var passPortPhoto = new LinkedResource("jamesBond.png", MediaTypeNames.Image.Png)
    {
        ContentId = "Image1",
        ContentType = new ContentType(MediaTypeNames.Image.Png),
        TransferEncoding = TransferEncoding.Base64
    };

    htmlView.LinkedResources.Add(passPortPhoto);
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
// Image from stream  
{
    // Setup logging
    Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

    var mail = new MailMessage();
    mail.From = new MailAddress("operations@MI5.co.uk", "M");
    mail.To.Add(new MailAddress("jbond@MI5.co.uk", "James Bond"));
    mail.Subject = "Happy Birthday James Again";

    // HTML body with image reference to linked resource by ID
    const string htmlBody = """
                            <html><body>
                            Good afternoon.
                            <br>
                            Have a happy birthday today!
                            <br>
                            <br>
                            <img src='cid:Image1' />
                            </body></html>
                            """;

    // AlternateView for HTML with linked image
    var htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);

    // This can be sourced from anywhere - API, Blob, database, etc 
    var bytes = File.ReadAllBytes("jamesBond.png");
    var stream = new MemoryStream(bytes);
    // Load image and link it to the HTML view
    var passPortPhoto = new LinkedResource(stream, MediaTypeNames.Image.Png)
    {
        ContentId = "Image1",
        ContentType = new ContentType(MediaTypeNames.Image.Png),
        TransferEncoding = TransferEncoding.Base64
    };

    htmlView.LinkedResources.Add(passPortPhoto);
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