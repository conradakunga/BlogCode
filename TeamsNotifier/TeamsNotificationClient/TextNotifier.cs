using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;

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

        var client = new HttpClient();
        // Set our headers
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        // Serialize anonymous type to JSON	
        var adaptiveCardJson = JsonSerializer.Serialize(request);
        // Create content for posting
        var content = new StringContent(adaptiveCardJson, System.Text.Encoding.UTF8, MediaTypeNames.Application.Json);
        // Post
        var response = await client.PostAsync(webhook, content);
        // Return success
        return response.IsSuccessStatusCode;
    }
}