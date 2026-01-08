using System.Collections.Specialized;
using Quartz;
using Serilog;

// Configure logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Create an empty nameValue collection to store the properties
var properties = new NameValueCollection();

// Create a scheduler
var scheduler = await SchedulerBuilder.Create(properties)
    .UsePersistentStore(x =>
    {
        x.UseProperties = true;
        x.UseClustering();
        x.UseSystemTextJsonSerializer();
        x.UsePostgres("host=localhost;username=myuser;password=mypassword;database=quartz");
    })
    .BuildScheduler();

// Start the scheduler
await scheduler.Start();

// Define job key
var jobKey = new JobKey("Recurring Job", "Group 1");
// Define trigger key
var triggerKey = new TriggerKey("Recurring Trigger", "Group 1");

// Check if job already exists
if (!await scheduler.CheckExists(jobKey))
{
    // It doesn't. Create one
    var recurringJob = JobBuilder.Create<NotificationJob>()
        .WithDescription("Print a notification periodically")
        .WithIdentity(jobKey)
        .StoreDurably() // Optional but recommended for persistent stores
        .Build();

    await scheduler.AddJob(recurringJob, replace: true); // safe on restarts
}

// Check if the trigger exists
if (!await scheduler.CheckExists(triggerKey))
{
    // It doesn't exist. Create one
    var recurringTrigger = TriggerBuilder.Create()
        // Set the identity to the trigger key
        .WithIdentity(triggerKey)
        // Link trigger to existing job
        .ForJob(jobKey)
        // Start immediately, then wait
        .StartNow()
        // Wait 10 seconds
        .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(10)
            .RepeatForever())
        .Build();

    // Schedule trigger (Quartz will create or replace if needed)
    await scheduler.ScheduleJob(recurringTrigger);
}

// wait for a minute
await Task.Delay(TimeSpan.FromMinutes(1));

// Shut down the schedular
await scheduler.Shutdown();