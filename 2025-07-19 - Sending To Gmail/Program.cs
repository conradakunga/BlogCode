using System.Net;
using System.Net.Mail;

const string fromAddress = "conradakunga@gmail.com";
const string fromPassword = "YOUR APP PASSWORD";

// Setup the SMTP server
var smtpClient = new SmtpClient
{
    Host = "smtp.gmail.com",
    Port = 587,
    EnableSsl = true,
    DeliveryMethod = SmtpDeliveryMethod.Network,
    UseDefaultCredentials = false,
    Credentials = new NetworkCredential(fromAddress, fromPassword)
};

// Create and send email
var mail = new MailMessage
{
    From = new MailAddress(fromAddress),
    Subject = "Test Email",
    Body = "This is a test email",
};

mail.To.Add("conradakunga@gmail.com");

try
{
    smtpClient.Send(mail);
    Console.WriteLine("Email sent successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to send email: {ex.Message}");
}