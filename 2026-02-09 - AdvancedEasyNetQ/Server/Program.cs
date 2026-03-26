using EasyNetQ;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Server;

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = Host.CreateDefaultBuilder(args);
builder.UseSerilog();

// Configure DI
builder.ConfigureServices((context, services) =>
{
    const string connection = "host=localhost;username=test;password=test";

    var options = new JsonSerializerOptions();
    services.AddEasyNetQ(connection).UseSystemTextJsonV2(options);
    services.AddHostedService<Publisher>();
});

// Start the application
var host = builder.Build();

await host.RunAsync();