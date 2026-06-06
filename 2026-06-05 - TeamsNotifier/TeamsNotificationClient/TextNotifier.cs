using System.Net.Http.Json;

namespace TeamsNotificationClient;

public sealed class TextNotifier
{
    private const string MessageType = "message";
    private const string CardContentType = "application/vnd.microsoft.card.adaptive";
    private const string CardType = "AdaptiveCard";
    private const string CardVersion = "1.2";
    private const string CardBodyType = "TextBlock";

    private readonly string webhook;

    public TextNotifier(string webhook)
    {
        this.webhook = webhook;
    }

    public async Task<bool> Post(string message)
    {
        var request = new
        {
            type = MessageType,
            attachments = new[]
            {
                new
                {
                    contentType = CardContentType,
                    content = new
                    {
                        type = CardType,
                        version = CardVersion,
                        body = new[]
                        {
                            new
                            {
                                type = CardBodyType,
                                text = $"{message}"
                            }
                        }
                    }
                }
            }
        };

        // Create a HttpClient
        var client = new HttpClient();
        // Post the request
        var response = await client.PostAsJsonAsync(webhook, request);
        // Return success
        return response.IsSuccessStatusCode;
    }
}