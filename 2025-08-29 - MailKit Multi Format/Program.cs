using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
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
message.Subject = "Christmas Card";

var builder = new BodyBuilder();

// Create a LinkedResource with the image
var image1 = builder.LinkedResources.Add("Bond1.jpeg");
// Generate an ID for use in linkage
image1.ContentId = MimeUtils.GenerateMessageId();

// Add the card attachment
builder.Attachments.Add("Card.txt");

// Build the html version of the message text using the IDs
var htmlBody = $"""
                <p>Dear M,<br/>
                <p>Merry Christmas From Me<br/>
                <br/
                <center>
                <img src="cid:{image1.ContentId}">
                </center>
                <p>James<br>
                """;

// Set the html body
builder.HtmlBody = htmlBody;

// Build the html version of the message text using the IDs
var body = """
           Dear M,

           Merry Christmas From Me

           James
           """;

// Set the plain text body
builder.TextBody = body;

// Set the message body 
message.Body = builder.ToMessageBody();

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