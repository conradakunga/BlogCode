using Serilog;

const int minutesToWait = 2;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// // Create a timer that executes RunTask every second, starting immediately. 
// var timer = new Timer(RunTask, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
// Log.Information("Timer started. Press Enter to exit...");
// Console.ReadLine();
// return;
//
// // Local function that runs the task
// void RunTask(object? state)
// {
//     // Get the current time
//     var currentTme = DateTime.Now;
//     // Check the minute and the second
//     if (currentTme.Minute % minutesToWait == 0 && currentTme.Second == 0)
//         Log.Information("Task executed at: {CurrentTime}", currentTme);
// }

// // Create a timer that executes RunTask every 2 minutes, starting immediately. 
// var timer = new Timer(RunTask, null, TimeSpan.Zero, TimeSpan.FromMinutes(minutesToWait));
// Log.Information("Timer started. Press Enter to exit...");
// Console.ReadLine();
// return;
//
// // Local function that runs the task
// void RunTask(object? state)
// {
//     Log.Information("Task executed at: {CurrentTime}", DateTime.Now);
// }

// Create a cancellation token source
using var cts = new CancellationTokenSource();
// Create the periodic timer
using var periodicTimer = new PeriodicTimer(TimeSpan.FromMinutes(minutesToWait));

// Write the handler for the work to be done
while (await periodicTimer.WaitForNextTickAsync(cts.Token))
{
    var currentDate = DateTime.Now;
    // If past noon, use 5 minutes. Else, the default
    if (currentDate.Hour >= 12)
        periodicTimer.Period = TimeSpan.FromMinutes(5);
    else
        periodicTimer.Period = TimeSpan.FromMinutes(minutesToWait);

    Log.Information("Task executed at: {CurrentTime}", currentDate);
}