using Quartz;
using Serilog;

try
{
    // Setup logging
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

    var builder = WebApplication.CreateBuilder(args);

    // Register Quartz  
    builder.Services.AddSerilog();
    builder.Services.AddQuartz();
    builder.Services.AddQuartzHostedService(opt => { opt.WaitForJobsToComplete = true; });

    var app = builder.Build();
    // Register dummy endpoint
    app.MapGet("/", () => "OK");

    // Fetch a Scheduler Factory from DI
    var schedulerFactory = app.Services.GetRequiredService<ISchedulerFactory>();
    var scheduler = await schedulerFactory.GetScheduler();

    // define the job 
    var job = JobBuilder.Create<NotificationJob>()
        .WithIdentity("Notification Job", "Group 1")
        .Build();

    // Trigger the job to run now, and then every 40 seconds
    var trigger = TriggerBuilder.Create()
        .WithIdentity("ASP.NET Job Trigger", "Group 1")
        .StartNow()
        .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(10)
            .RepeatForever())
        .Build();
    await scheduler.ScheduleJob(job, trigger);
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