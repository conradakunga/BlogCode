public sealed class CaseSensitiveHeaderHandler :
    HttpClientHandler
{
    private readonly string _headerName;
    private readonly string _headerValue;

    public CaseSensitiveHeaderHandler(string headerName, string headerValue)
    {
        // Validate the incoming values
        ArgumentException.ThrowIfNullOrWhiteSpace(headerName);
        ArgumentException.ThrowIfNullOrWhiteSpace(headerValue);
        // Set the values
        _headerName = headerName;
        _headerValue = headerValue;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // Set our headers
        request.Headers.Add(_headerName, _headerValue);
        return base.SendAsync(request, cancellationToken);
    }
}