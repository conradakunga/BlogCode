// This namespace contains the HttpProtocols enum
using Microsoft.AspNetCore.Server.Kestrel.Core;
// This namespace contains the IPAddress type
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Configure kestrel
builder.WebHost.ConfigureKestrel((context, options) =>
{
    // Listen on port 5001
    options.Listen(IPAddress.Any, 5001, listenOptions =>
    {
        // Serve traffic usingg HTTP/2 or HTTP/3
        listenOptions.Protocols = HttpProtocols.Http2 | HttpProtocols.Http3;
        // Use HTTPS
        listenOptions.UseHttps();
    });
});

var app = builder.Build();

// Configure the root to also accept GET requests
app.MapGet("/", () => $"The time on the server is {DateTime.Now}");

app.Run();
