using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Me.SendMail;
using Microsoft.Graph.Models;

var scopes = new[] { "User.Read" };

// Multi-tenant apps can use "common",
// single-tenant apps must use the tenant ID from the Azure portal
var tenantId = "common";

// Value from app registration
var clientId = "YOUR_CLIENT_ID";

// using Azure.Identity;
var options = new DeviceCodeCredentialOptions
{
    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
    ClientId = clientId,
    TenantId = tenantId,
    // Callback function that receives the user prompt
    // Prompt contains the generated device code that user must
    // enter during the auth process in the browser
    DeviceCodeCallback = (code, cancellation) =>
    {
        Console.WriteLine(code.Message);
        return Task.FromResult(0);
    },
};

// https://learn.microsoft.com/dotnet/api/azure.identity.devicecodecredential
var deviceCodeCredential = new DeviceCodeCredential(options);

var graphClient = new GraphServiceClient(deviceCodeCredential, scopes);

var requestBody = new SendMailPostRequestBody
{
    Message = new Message
    {
        Subject = "9/9/2018: concert",
        Body = new ItemBody
        {
            ContentType = BodyType.Html,
            Content = "The group represents Nevada.",
        },
        ToRecipients = new List<Recipient>
        {
            new Recipient
            {
                EmailAddress = new EmailAddress
                {
                    Address = "AlexW@contoso.com",
                },
            },
        },
        InternetMessageHeaders = new List<InternetMessageHeader>
        {
            new InternetMessageHeader
            {
                Name = "x-custom-header-group-name",
                Value = "Nevada",
            },
            new InternetMessageHeader
            {
                Name = "x-custom-header-group-id",
                Value = "NV001",
            },
        },
    },
};


// To initialize your graphClient, see https://learn.microsoft.com/en-us/graph/sdks/create-client?from=snippets&tabs=csharp
await graphClient.Me.SendMail.PostAsync(requestBody);