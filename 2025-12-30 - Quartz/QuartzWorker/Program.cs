using Quartz;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);

try
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

    builder.Services.AddQuartz(x =>
    {
        // Define a jey for the job
        var jobKey = new JobKey("Notification Job");

        // Add the job
        x.AddJob<NotificationJob>(opts => opts.WithIdentity(jobKey));

        // Add the trigger
        x.AddTrigger(opts => opts
            .ForJob(jobKey)
            .WithIdentity("Notification Trigger")
            .StartNow()
            .WithSimpleSchedule(_ => _
                .WithInterval(TimeSpan.FromSeconds(10))
                .RepeatForever()));
    }).AddSerilog();

    builder.Services.AddQuartzHostedService(options => { options.WaitForJobsToComplete = true; });

    var app = builder.Build();

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