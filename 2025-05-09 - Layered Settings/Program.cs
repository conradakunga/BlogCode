using ApplicationSettings.Properties;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine(Environment.MachineName);

// Load our company settings, that are mandatory
builder.Configuration.AddJsonFile("companysettings.json", optional: false);
// Load optional developer-specific settings
builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true);

// Configure options DI
builder.Services.AddOptions<SystemSettings>()
    .Bind(builder.Configuration.GetSection(nameof(SystemSettings)));

var app = builder.Build();

app.MapGet("/", (IOptions<SystemSettings> options) =>
{
    var settings = options.Value;
    return settings;
});

app.Run();