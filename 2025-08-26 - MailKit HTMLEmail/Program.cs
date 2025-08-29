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
message.Subject = "Deployment Status - Follow Up";

var textBody = new TextPart("html")
{
    Text = """
           Dear M,
           <br/>
           <br/>
           Subject Refers.
           <br/>
           <br/>
           I would like to <i>kindly</i> follow up on my last email requesting to know my deployment
           status.
           <br/>
           <br/>
           <b>I have been at home for six weeks now!<b>.
           """
};

message.Body = textBody;

// Now send the email
using (var client = new SmtpClient())
{
    Log.Information("Connecting to smtp server...");
    await client.ConnectAsync("localhost", 25, false);
    //Typically, authenticate here. But we are using PaperCut 
    //await client.AuthenticateAsync("joey", "password");
    await client.SendAsync(message);
    Log.Information("Sent message");
    await client.DisconnectAsync(true);
    Log.Information("Disconnected from server");
}