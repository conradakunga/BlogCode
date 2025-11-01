using DBApi;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// If running in devolopment, load settings by developer machine
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: false);
}

// Register settings with DI
builder.Services.AddOptions<ConnectionStrings>()
    .Bind(builder.Configuration.GetSection("ConnectionStrings"));

var app = builder.Build();

app.MapGet("/", (IOptions<ConnectionStrings> options) =>
{
    var settings = options.Value;
    return new
    {
        Database = settings.DatabaseConnectionString,
        Redis = settings.RedisConnectionString
    };
});

app.Run();