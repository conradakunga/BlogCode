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
message.Subject = "Birthday Wishes";

var builder = new BodyBuilder();

// Create a LinkedResource with the image
var image1 = builder.LinkedResources.Add("Bond1.jpeg");
// Generate an ID for use in linkage
image1.ContentId = MimeUtils.GenerateMessageId();
// Generate a second ID for use in linkage
var image2 = builder.LinkedResources.Add("Bond2.jpeg");
image2.ContentId = MimeUtils.GenerateMessageId();

// Build the html version of the message text using the IDs
var body = $"""
            <p>Dear M,<br>
            <p>Happy birthday!<br>
            <p>Warmest regards of the day<br>
            <p>Find attached my favourite pictures<br>
            <p>James<br>
            <center>
            <img src="cid:{image1.ContentId}">
            <img src="cid:{image2.ContentId}">
            </center>
            """;
// Set the html body
builder.HtmlBody = body;

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