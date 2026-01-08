using Quartz;
using Quartz.Impl;
using Serilog;

// Configure logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Create a scheduler
var factory = new StdSchedulerFactory();
var scheduler = await factory.GetScheduler();

// Start the scheduler
await scheduler.Start();

// Define our timed job
var timedJob = JobBuilder.Create<NotificationJob>()
    .WithDescription("Print a notification periodically")
    .WithIdentity("Recurring Job", "Group 1")
    .Build();

//  Define the trigger for the timed job
var timedTrigger = TriggerBuilder.Create()
    .WithIdentity("Recurring Trigger", "Group 1")
    // every day at 12:00
    .WithCronSchedule("0 55 14 * * ?")
    .Build();

// Register job with quartz
await scheduler.ScheduleJob(timedJob, timedTrigger);

// wait for a minute
await Task.Delay(Timeout.Infinite);

// Shut down the schedular
await scheduler.Shutdown();