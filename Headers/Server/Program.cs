var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
}).CreateLogger("Program");

app.MapGet("/", (HttpRequest req) =>
{
    var counter = 1;
    foreach (var header in req.Headers)
    {
        logger.LogInformation("{Counter} - {Key}:{Value}", counter++, header.Key, header.Value);
    }
});

app.Run();
