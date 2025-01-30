using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting ...");
// Create an ATM Booth
var booth = new ATMBooth();
Log.Information("Started ...");
Log.Information("Initiating Withdrawal ...");
// Do a withdrawal
booth.ATM.Withdraw(1_000);
// Do a second withdrawal
booth.ATM.Withdraw(2_000);
