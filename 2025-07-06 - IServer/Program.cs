using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (IServer server, ILogger<Program> logger) =>
{
    // Query the server addresses
    var addresses = server.Features.Get<IServerAddressesFeature>()?.Addresses;
    // Log the number found
    logger.LogInformation("Listening on {AddressCount} addresses", addresses?.Count ?? 0);
    // Loop through the results and log
    foreach (var address in addresses!)
        logger.LogInformation("- {Address}", address);
});

app.Run();