using Serilog;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

// Start fake task
Log.Information("Starting a long task");
// Sleep for 10 seconds synchronously
Thread.Sleep(TimeSpan.FromSeconds(10));
Log.Information("Completed long task");


// Start fake task
Log.Information("Starting a long task");
// Sleep for 10 seconds asynchronously
await Task.Delay(TimeSpan.FromSeconds(10));
Log.Information("Completed long task");

// // Start fake task
Log.Information("Starting a long task");
// Create a cancellation token source
var cts = new CancellationTokenSource();
// Invoke method, and pass delay and token
await ComplexOperation(10, cts.Token);
Log.Information("Completed long task");
return;

// Complex method here that has a delay within
async Task ComplexOperation(int delayInSeconds, CancellationToken token)
{
    await Task.Delay(TimeSpan.FromSeconds(delayInSeconds), token);
}