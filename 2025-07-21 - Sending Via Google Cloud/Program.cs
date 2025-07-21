using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Users.Item.SendMail;

const string applicationID = "APPLICATION_ID";
const string tenantID = "TENANT_ID";
const string secretValue = "CLIENT_SECRET";
const string fromAddress = "cakunga@innova.co.ke";
const string toAddress = "conradakunga@gmail.com";

try
{
    // Set our scopes to the default
    var scopes = new[] { "https://graph.microsoft.com/.default" };

    // Create TokenCredential
    var credential = new ClientSecretCredential(tenantID, applicationID, secretValue);

    // Create Graph client
    var graphClient = new GraphServiceClient(credential, scopes);

    // Build email
    var message = new Message
    {
        Subject = "Test Email",
        Body = new ItemBody
        {
            ContentType = BodyType.Text,
            Content = "Test email"
        },
        ToRecipients =
        [
            new Recipient
            {
                EmailAddress = new EmailAddress
                {
                    Address = toAddress
                }
            }
        ]
    };

    // Send email
    await graphClient.Users[fromAddress].SendMail.PostAsync(new SendMailPostRequestBody
    {
        Message = message
    });
    
    Console.WriteLine("Message sent");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}