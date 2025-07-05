var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Inject the request and a logger
app.MapGet("/", (HttpRequest req, ILogger<Program> logger) =>
{
    // Log all our received headers
    foreach (var header in req.Headers)
    {
        logger.LogInformation("Key: {Key}; Value {Value} ", header.Key, header.Value);
    }
});

app.Run();