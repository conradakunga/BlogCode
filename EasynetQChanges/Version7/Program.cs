using EasyNetQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBus>(_ => RabbitHutch.CreateBus(builder.Configuration.GetConnectionString("RabbitMQ")));

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