// Get the temp folder

using System.Net;
using System.Net.Mail;

// Use pickup folder
{
    var pickupFolder = Path.GetTempPath();

    Console.WriteLine($"Setting delivery location to directory {pickupFolder}");

    // Setup the SMTP client
    var smtpClient = new SmtpClient
    {
        DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
        PickupDirectoryLocation = pickupFolder
    };

    // Create and send email
    var mail = new MailMessage
    {
        From = new MailAddress("your-email@gmail.com"),
        Subject = "Test Email",
        Body = "This is a test email",
    };

    mail.To.Add("recipient@example.com");

    try
    {
        smtpClient.Send(mail);
        Console.WriteLine("Email sent successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to send email: {ex.Message}");
    }
}
// use SMTP server
{
    var smtpClient = new SmtpClient
    {
        Host = "102.168.0.67",
        Port = 24,
        Credentials = CredentialCache.DefaultNetworkCredentials,
        EnableSsl = true
    };
    
    Console.WriteLine($"Setting delivery location to server {smtpClient.Host}");

    // Create and send email
    var mail = new MailMessage
    {
        From = new MailAddress("your-email@gmail.com"),
        Subject = "Test Email",
        Body = "This is a test email",
    };

    mail.To.Add("recipient@example.com");

    try
    {
        smtpClient.Send(mail);
        Console.WriteLine("Email sent successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to send email: {ex.Message}");
    }
}