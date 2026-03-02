using Microsoft.EntityFrameworkCore;
using Serilog;
using TickerQ.Dashboard.DependencyInjection;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore.DbContextFactory;
using TickerQ.EntityFrameworkCore.DependencyInjection;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSerilog();

builder.Services.AddDbContext<TickerQDbContext>(options =>
    options.UseNpgsql("Server=localhost;Port=5432;Database=tickerq;User Id=myuser;Password=mypassword"));

// Register TickerQ services
builder.Services.AddTickerQ(options =>
{
    options.AddOperationalStore(efOptions =>
    {
        // Use built-in TickerQDbContext with connection string
        efOptions.UseTickerQDbContext<TickerQDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=tickerq;User Id=myuser;Password=mypassword;",
                cfg =>
                {
                    // Retry configuration
                    cfg.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), ["40P01"]);
                    // Set the assembly from which to retrieve migrations.
                    // In this case, the current assembly
                    cfg.MigrationsAssembly("TickerQWebDatabase");
                });
        });
    });
    options.AddDashboard(config =>
    {
        // configure security
        config.WithBasicAuth("admin", "admin");
    });
});

var app = builder.Build();

app.UseTickerQ();
// Activate the processor
await app.RunAsync();