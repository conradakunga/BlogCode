using Hangfire;
using Hangfire.AspNetCore;
using Hangfire.PostgreSql;
using Logic;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

// Configure logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var services = new ServiceCollection();
services.AddLogging(builder => builder.AddSerilog());
// Register the job for DI
services.AddTransient<NotificationJob>();

var serviceProvider = services.BuildServiceProvider();

// Configure hangfire
GlobalConfiguration.Configuration
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(x =>
    {
        x.UseNpgsqlConnection("host=localhost;Database=hangfire;username=myuser;password=mypassword");
    })
    // Configure how to resolve DI object activation
    .UseActivator(new AspNetCoreJobActivator(serviceProvider.GetRequiredService<IServiceScopeFactory>()));

// Start the server
using (var server = new BackgroundJobServer())
{
    BackgroundJob.Enqueue<NotificationJob>(x => x.ExecuteLengthy());

    // Artificial wait
    await Task.Delay(TimeSpan.FromMinutes(5));

    // Shutdown server
    Log.Information("Shutting down BackgroundJobServer...");
    await server.WaitForShutdownAsync(CancellationToken.None);
}