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
        "Every Minute Job",
        job => job.Execute(),
        Cron.Minutely()
    );

    // Artificial wait
    await Task.Delay(TimeSpan.FromMinutes(5));

    // Shutdown server
    await server.WaitForShutdownAsync(CancellationToken.None);
}