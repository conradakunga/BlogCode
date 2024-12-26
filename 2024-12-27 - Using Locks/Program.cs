using LockingSupport;
using Serilog;

// Create logger configuration
var config = new LoggerConfiguration()
    // Enrich with thread id
    .Enrich.WithThreadId()
    // Write to console with specified template
    .WriteTo.Console(
        outputTemplate:
        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} Thread:<{ThreadId}> [{Level:u3}] {Message:lj} {NewLine}{Exception}");

// Create the logger
Log.Logger = config.CreateLogger();

// Create an account
var account = new Account();

// Create a list of tasks to deposit and withdraw money
// at the end the balance should be 0
List<Task> tasks = [];
for (var i = 0; i < 25; i++)
{
    tasks.Add(Task.Run(() =>
    {
        account.Deposit(1000);
        Log.Information("The balance after deposit is {Balance:#,0.00}", account.Balance);
    }));

    tasks.Add(Task.Run(() =>
    {
        account.Withdraw(1000);
        Log.Information("The balance after withdrawal is {Balance:#,0.00}", account.Balance);
    }));
}

// Execute all the tasks
await Task.WhenAll(tasks);

// Print final balance
Console.WriteLine($"The final balance is {account.Balance:#,0.00}");