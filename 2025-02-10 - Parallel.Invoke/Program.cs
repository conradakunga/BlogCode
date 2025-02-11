using Serilog;

Log.Logger = new LoggerConfiguration()
    .Enrich.WithThreadId()
    .WriteTo.Console(
        outputTemplate:
        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3} Thread:{ThreadId}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

// Process James Bond
ProcessSpy("James Bond");
// Process Vesper Lynd
ProcessSpy("Verpser Lynd");
// Process Eve Moneypeny
ProcessSpy("Eve Moneypeny");
// Process Q
ProcessSpy("Q");
// Process M
ProcessSpy("M");


Parallel.Invoke(
    () => ProcessSpy("James Bond"),
    () => ProcessSpy("Vesper Lynd"),
    () => ProcessSpy("Eve Moneypenny"),
    () => ProcessSpy("Q"),
    () => ProcessSpy("M")
);
return;

void ProcessSpy(string name)
{
    Log.Information("Starting to Process {Name} ...", name);
    Thread.Sleep(TimeSpan.FromSeconds(25));
    Log.Information("Completed Processing {Name} ...", name);
}