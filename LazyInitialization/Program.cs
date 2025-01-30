using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting...");
// Create an ATM Booth
var booth = new ATMBooth();
booth.ATM.Withdraw(1_000);