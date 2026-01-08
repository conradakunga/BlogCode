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

// Define our recurring job
var recurringJob = JobBuilder.Create<NotificationJob>()
    .WithDescription("Print a notification periodically")
    .WithIdentity("Recurring Job", "Group 1")
    .Build();

//  Define the trigger for the recurring job
var recurringTrigger = TriggerBuilder.Create()
    .WithIdentity("Recurring Trigger", "Group 1")
    // Start immediately
    .StartNow()
    // Schedule every 10 seconds
    .WithSimpleSchedule(x => x.WithIntervalInSeconds(10)
        .RepeatForever())
    .Build();

// Register job with quartz
await scheduler.ScheduleJob(recurringJob, recurringTrigger);

// wait for a minute
await Task.Delay(TimeSpan.FromMinutes(1));

// Shut down the schedular
await scheduler.Shutdown();