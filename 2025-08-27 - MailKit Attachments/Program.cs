using MailKit.Net.Smtp;
using MimeKit;
using Serilog;

// Configure logging to the console
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Create the email
var message = new MimeMessage();
// Add the sender
message.From.Add(new MailboxAddress("James Bond", "james@mi5.org"));
// Set the recipient
message.To.Add(new MailboxAddress("M", "m@mi5.org"));
// Set the email subject
message.Subject = "Mission Listing";

// Create the text body
var textBody = new TextPart("plain")
{
    Text = """
           Dear M,

           As requested, kindly find attached a list of the missions I have carried
           out since you took over command.

           Warest regards
           """
};

// create the attachment
var attachment = new MimePart("text", "plain")
{
    Content = new MimeContent(File.OpenRead("Missions.txt")),
    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
    ContentTransferEncoding = ContentEncoding.Base64,
    FileName = "Missions.txt"
};

// Create a container for the body text & attachment
var parts = new Multipart("mixed");
parts.Add(textBody);
parts.Add(attachment);

// Set the body
message.Body = parts;

// Now send the email
using (var client = new SmtpClient())
{
    Log.Information("Connecting to smtp server...");
    await client.ConnectAsync("localhost", 25, false);
    // Typically, authenticate here. But we are using PaperCut 
    //await client.AuthenticateAsync("username", "password");
    await client.SendAsync(message);
    Log.Information("Sent message");
    await client.DisconnectAsync(true);
    Log.Information("Disconnected from server");
}