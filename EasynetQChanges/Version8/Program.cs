using EasyNetQ;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEasyNetQ(builder.Configuration.GetConnectionString("RabbitMQ"))
    .UseSystemTextJsonV2();
var app = builder.Build();

app.MapGet("/", async (IBus bus, ILogger<Program> logger) =>
{
    try
    {
        logger.LogInformation("Publishing message ...");

        // Publish a message
        await bus.PubSub.PublishAsync("hello");

        // Return OK
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.InternalServerError(ex.Message);
    }
});

await app.RunAsync();