using System.Text.Json;
using Client;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

// Setup logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = Host.CreateDefaultBuilder(args);
builder.UseSerilog();

// Configure DI
builder.ConfigureServices((context, services) =>
{
    const string connection = "host=localhost;username=test;password=test";

    // Configure our serializer to attach the JsonConverer
    var options = new JsonSerializerOptions
    {
        Converters = { new JsonTimeAdjustedConverter() }
    };

    // Wire in EasyNetQ
    services.AddEasyNetQ(connection).UseSystemTextJsonV2(options);
    services.AddHostedService<Subscriber>();
});

// Build the host
var host = builder.Build();

// Start the app
await host.RunAsync();