using System.Net.Mail;
using System.Net.Mime;

// Simple email
var mail = new MailMessage
{
    From = new MailAddress("your-email@gmail.com"),
    Subject = "Test Email",
    Body = "This is a test email",
};

mail.To.Add("recipient@example.com");

// Html email
mail = new MailMessage
{
    From = new MailAddress("your-email@gmail.com"),
    Subject = "Test Email",
    Body = "<b>This is a test email<b> sent from .NET",
    IsBodyHtml = true
};

mail.To.Add("recipient@example.com");

// Multiple TO addressees
mail = new MailMessage
{
    From = new MailAddress("your-email@gmail.com"),
    Subject = "Test Email",
    Body = "This is a test email",
};

mail.To.Add("recipient@example.com");
mail.To.Add("secondrecipient@example.com");


// CC addressee
mail = new MailMessage
{
    From = new MailAddress("your-email@gmail.com"),
    Subject = "Test Email",
    Body = "This is a test email",
};

mail.To.Add("recipient@example.com");
mail.CC.Add("secondrecipient@example.com");

// BCC addressee
mail = new MailMessage
{
    From = new MailAddress("your-email@gmail.com"),
    Subject = "Test Email",
    Body = "This is a test email",
};

mail.To.Add("recipient@example.com");
mail.CC.Add("secondrecipient@example.com");
mail.Bcc.Add("thirdrecipient@example.com");

// Attach file from file systemm
mail = new MailMessage
{
    From = new MailAddress("your-email@gmail.com"),
    Subject = "Test Email",
    Body = "This is a test email",
};

mail.Attachments.Add(new Attachment("/Users/rad/Downloads/Digital Kenya.pdf"));

mail.To.Add("recipient@example.com");
mail.CC.Add("secondrecipient@example.com");
mail.Bcc.Add("thirdrecipient@example.com");

// Attach file from stream

// Fetch the stream from whichever source
using (var stream = File.OpenRead("/Users/rad/Downloads/Digital Kenya.pdf"))
{
    mail = new MailMessage
    {
        From = new MailAddress("your-email@gmail.com"),
        Subject = "Test Email",
        Body = "This is a test email",
    };

    mail.Attachments.Add(new Attachment(stream, "Digital Kenya.pdf"));

    mail.To.Add("recipient@example.com");
    mail.CC.Add("secondrecipient@example.com");
    mail.Bcc.Add("thirdrecipient@example.com");
}

// Alternate views
mail = new MailMessage
{
    From = new MailAddress("your-email@gmail.com"),
    Subject = "Test Email",
};

// Define plain text
const string plainText = "This is a test email";
var plainView = AlternateView.CreateAlternateViewFromString(plainText, null, MediaTypeNames.Text.Plain);

// Define HTML
const string html = "<b>This is a test email<b> sent from .NET";
var htmlView = AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html);

// Attach views
mail.AlternateViews.Add(plainView);
mail.AlternateViews.Add(htmlView);

mail.To.Add("recipient@example.com");
mail.CC.Add("secondrecipient@example.com");
mail.Bcc.Add("thirdrecipient@example.com");