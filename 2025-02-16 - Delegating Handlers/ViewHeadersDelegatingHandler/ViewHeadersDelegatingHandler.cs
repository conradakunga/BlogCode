using Serilog;

namespace ViewHeaders;

public sealed class ViewHeadersDelegatingHandler : DelegatingHandler
{
    public ViewHeadersDelegatingHandler() : base(new HttpClientHandler())
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Log request header summary
        Log.Information("REQUEST HEADERS: {Count}", request.Headers.Count());
        foreach (var header in request.Headers)
        {
            // Log each header
            Log.Information("{Header} : {Value}", header.Key, string.Join(", ", header.Value));
        }

        // Check if the request contents have headers
        if (request.Content?.Headers != null)
        {
            // Log request content header summary
            Log.Information("REQUEST CONTENT HEADERS: {Count}", request.Content.Headers.Count());
            foreach (var header in request.Content.Headers)
            {
                // Log each header
                Log.Information("{Header} : {Value}", header.Key, string.Join(", ", header.Value));
            }
        }

        Log.Information("Sending request to {URL}", request.RequestUri);

        // Send the request and get the response
        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

        // Log response headers summary
        Log.Information("RESPONSE HEADERS: {Count}", response.Headers.Count());
        foreach (var header in response.Headers)
        {
            // Log each header
            Log.Information("{Header} : {Value}", header.Key, string.Join(", ", header.Value));
        }

        // Check if response content has headers. It is unlikely
        // for the content to be null, but check anyway
        if (response.Content?.Headers != null)
        {
            Log.Information("RESPONSE CONTENT HEADERS: {Count}", response.Content.Headers.Count());
            foreach (var header in response.Content.Headers)
            {
                // Log each header
                Log.Information("{Header} : {Value}", header.Key, string.Join(", ", header.Value));
            }
        }

        Log.Information("Request complete");

        return response;
    }
}