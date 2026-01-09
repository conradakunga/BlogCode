using Hangfire;
using Hangfire.PostgreSql;
using Logic;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSerilog();

// Add services
builder.Services.AddHangfire(config =>
{
    config.UseSimpleAssemblyNameTypeSerializer();
    config.UseRecommendedSerializerSettings();
    config.UsePostgreSqlStorage(options =>
    {
        options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("Hangfire"));
    });
});

// Add server
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the hangfire dashboard
app.UseHangfireDashboard();

// Noe register the jobs

// Get a recurring job manager form DI container
var recurringJobManager = app.Services.GetRequiredService<IRecurringJobManager>();

// Register our job that fires every minute
recurringJobManager.AddOrUpdate<NotificationJob>(
    "ASP.NET Every Minute Job",
    job => job.Execute(),
    Cron.Minutely()
);

app.MapGet("/", () => "OK");

await app.RunAsync();