using Greeter.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Configure our host
using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Register the system clock to be returned whenever an IClock is requested
        services.AddSingleton<IClock, SystemClock>();
        // Register our greeter
        services.AddSingleton<Greeter.Logic.Greeter>();
    })
    .Build();

// Get the built in logger from the container
var logger = host.Services.GetRequiredService<ILoggerFactory>().CreateLogger<Program>();
// Get a greeter from the container
var greeter = host.Services.GetRequiredService<Greeter.Logic.Greeter>();
// Perform the business logic
logger!.LogInformation("{Greeting} world!", greeter!.Greet());