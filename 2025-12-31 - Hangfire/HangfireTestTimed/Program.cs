using Hangfire;
using Hangfire.PostgreSql;
using Logic;
using Serilog;

// Configure logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Configure hangfire
GlobalConfiguration.Configuration
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(x =>
    {
        x.UseNpgsqlConnection("host=localhost;Database=hangfire;username=myuser;password=mypassword");
    });

// Start the server
using (var server = new BackgroundJobServer())
{
    // Create / update a recurring job
    RecurringJob.AddOrUpdate<NotificationJob>(
        "Daily Timed At 11:50",
        job => job.Execute(),
        // The time in UTC
        Cron.Daily(8, 50)
    );
    
    Log.Information("Registered ...");

    // Artificial wait
    await Task.Delay(-1);

    Log.Information("Shutting Down");

    // Shutdown server
    await server.WaitForShutdownAsync(CancellationToken.None);
}