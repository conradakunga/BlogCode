using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using MimeKit;

// Setup our parameters
const string applicationName = "EmailAppDesktopClient";
const string fromAddress = "conradakunga@gmail.com";
const string toAddress = "cakunga@innova.co.ke";

try
{
    // Set our desired scopes
    var scopes = new[] { GmailService.Scope.GmailSend };

    // Read our credentials from JSON
    UserCredential credential;
    await using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
    {
        credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.FromStream(stream).Secrets,
            scopes, "user", CancellationToken.None
        );
    }

    // Initialize the service
    var service = new GmailService(new BaseClientService.Initializer
    {
        HttpClientInitializer = credential,
        ApplicationName = applicationName
    });

    // Create a MIME message
    var email = new MimeMessage();
    email.From.Add(new MailboxAddress(fromAddress, fromAddress));
    email.To.Add(new MailboxAddress(toAddress, toAddress));
    email.Subject = "Test Subject";
    email.Body = new TextPart("plain")
    {
        Text = "Test Email"
    };

    // Encode the message
    using var memoryStream = new MemoryStream();
    email.WriteTo(memoryStream);
    var rawMessage = Convert.ToBase64String(memoryStream.ToArray())
        .Replace('+', '-').Replace('/', '_').Replace("=", "");

    // Create a message
    var message = new Message
    {
        Raw = rawMessage,
    };

    // Send the message
    await service.Users.Messages.Send(message, "me").ExecuteAsync();

    Console.WriteLine("Message sent");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}