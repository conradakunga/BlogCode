using Hangfire;
using Hangfire.PostgreSql;
using Logic;
using Serilog;


try
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

    var builder = Host.CreateApplicationBuilder(args);

    // Add services
    builder.Services.AddSerilog();
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

    // Now register the jobs

    // Get a recurring job manager form DI container
    var recurringJobManager = app.Services.GetRequiredService<IRecurringJobManager>();

    // Register our job that fires every minute
    recurringJobManager.AddOrUpdate<NotificationJob>(
        "Worker Service Every Minute Job",
        job => job.Execute(),
        Cron.Minutely()
    );
    
    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated");
}
finally
{
    Log.CloseAndFlush();
}