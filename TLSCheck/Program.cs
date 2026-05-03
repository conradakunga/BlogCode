using System.Security.Authentication;
using Microsoft.AspNetCore.Connections.Features;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Setup endpoint
app.MapGet("/", (HttpContext context) =>
{
    // Fetch feature info
    var tlsFeature = context.Features.Get<ITlsHandshakeFeature>();
    // fetch protocol
    var protocol = tlsFeature?.Protocol;
    // build message
    var result = protocol switch
    {
        SslProtocols.Tls12 => "TLS 1.2 (Current)",
        SslProtocols.Tls13 => "TLS 1.3 (Latest",
        _ => "Legacy / Unsupported"
    };

    // Return result
    return $"TLS Version: {result}";
});

await app.RunAsync();