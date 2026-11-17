// Use Serilog console sink with a thread enricher to display the Thread ID	

using System.Globalization;
using Serilog;

Log.Logger = new LoggerConfiguration()
    // Enrich
    .Enrich.WithThreadId()
    // Customize output template
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] [Thread {ThreadId}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

var now = DateTime.Now;

// Create our tasks
var kenyan = Task.Run(() =>
{
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-KE");
    Log.Information("{Country} {Date}", "Kenya", now.ToShortDateString());
    // Custom processing here
});

var canada = Task.Run(() =>
{
    Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
    Log.Information("{Country} {Date}", "Canada", now.ToShortDateString());
    // Custom processing here
});

var america = Task.Run(() =>
{
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    Log.Information("{Country} {Date}", "America", now.ToShortDateString());
    // Custom processing here
});

// Await all our threads
await Task.WhenAll(kenyan, canada, america);