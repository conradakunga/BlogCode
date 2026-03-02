using System.Reflection;
using Serilog;
using TickerQ.DependencyInjection;
using ILogger = Serilog.ILogger;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSerilog();
// Register TickerQ services
builder.Services.AddTickerQ();

var app = builder.Build();
app.UseTickerQ();
Log.Information(Assembly.GetExecutingAssembly().GetName().Name!);
// Activate the processor
await app.RunAsync();