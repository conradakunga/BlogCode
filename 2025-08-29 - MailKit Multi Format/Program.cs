using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MimeKit.Utils;
using Serilog;

// Configure logging to the console
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

const string fromAddress = "conradakunga@gmail.com";
const string toAddress = "cakunga@innova.co.ke";
const string fromPassword = "<YOUR APP PASSWORD HERE>";

// Create the email
var message = new MimeMessage();
// Add the sender
message.From.Add(new MailboxAddress("James Bond", fromAddress));
// Set the recipient
message.To.Add(new MailboxAddress("M", toAddress));
// Set the email subject
message.Subject = "Mission Brief";

var briefStart = new DateTime(2025, 8, 29, 10, 0, 0);
var briefEnd = new DateTime(2025, 8, 29, 10, 0, 0);
const string briefLocation = "MI6 HQ, London";

var plainText = $"""
                 Dear sir,

                 The schedule for the briefing is as follows:

                 Location: {briefLocation}

                 Start Date: {briefStart:d MMM yyyy HH:mm}
                 End Date: {briefEnd:d MMM yyyy HH:mm}
                 """;


var plainTextPart = new TextPart(TextFormat.Plain)
{
    Text = plainText
};

// Build the iCalendar content
var calendarText = $"""
                    BEGIN:VCALENDAR
                    PRODID:-//MI6//Mission Briefing//EN
                    VERSION:2.0
                    METHOD:REQUEST
                    BEGIN:VEVENT
                    UID:{Guid.NewGuid()}
                    DTSTAMP:{DateTime.UtcNow:yyyyMMddTHHmmssZ}
                    DTSTART:{briefStart:yyyyMMddTHHmmssZ}
                    DTEND:{briefEnd:yyyyMMddTHHmmssZ}
                    SUMMARY:Mission Briefing
                    DESCRIPTION:Briefing on the upcoming mission.
                    LOCATION:{briefLocation}
                    STATUS:CONFIRMED
                    SEQUENCE:0
                    BEGIN:VALARM
                    TRIGGER:-PT15M
                    ACTION:DISPLAY
                    DESCRIPTION:Reminder
                    END:VALARM
                    END:VEVENT
                    END:VCALENDAR
                    """;

// Create the calendar part
var calendarPart = new TextPart("calendar")
{
    Text = calendarText,
    ContentTransferEncoding = ContentEncoding.Base64,
    ContentDisposition = new ContentDisposition(ContentDisposition.Inline)
    {
        FileName = "invite.ics"
    }
};

// Set the method and name parameter values
calendarPart.ContentType.Parameters.Add("method", "REQUEST");

// Create multipart/alternative so clients can pick plain text or calendar
var alternativePart = new Multipart("alternative");
alternativePart.Add(plainTextPart);
alternativePart.Add(calendarPart);

// Set message body
message.Body = alternativePart;

// Now send the email
using (var client = new SmtpClient())
{
    Log.Information("Connecting to smtp server...");
    await client.ConnectAsync("smtp.gmail.com", 587, false);
    await client.AuthenticateAsync(fromAddress, fromPassword);
    await client.SendAsync(message);
    Log.Information("Sent message");
    await client.DisconnectAsync(true);
    Log.Information("Disconnected from server");
}