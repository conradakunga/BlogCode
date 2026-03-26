using System.Text.Json;
using EasyNetQ;

var builder = WebApplication.CreateBuilder(args);

// Set up our serialization options
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
    WriteIndented = true
};

// Register our DI
builder.Services.AddEasyNetQ(builder.Configuration.GetConnectionString("RabbitMQ"))
    .UseSystemTextJsonV2(options); // Set the serialization options

var app = builder.Build();

app.MapGet("/", async (IBus bus, ILogger<Program> logger) =>
{
    try
    {
        var spy = new Spy("James", "Bond");

        logger.LogInformation("Publishing message ...");

        // Publish a message
        await bus.SendReceive.SendAsync("SpyQueue", spy);

        // Return OK
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.InternalServerError(ex.Message);
    }
});

await app.RunAsync();