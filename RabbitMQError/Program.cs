using EasyNetQ.Management.Client;
using Serilog;

// Configure logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Fetch / configure access parameters
var username = "test";
var password = "test";
var hostAddress = "localhost";
var adminPort = 15672;
var queueName = "EasyNetQ_Default_Error_Queue";

Log.Information("Connecting to {Host} on Port {Port}", hostAddress, adminPort);

// Create a management client
var mc = new ManagementClient(new Uri($"http://{hostAddress}:{adminPort}"), username, password);
try
{
    // Fetch the queue form the default vHost
    var queue = await mc.GetQueueAsync("/", queueName);

    // Check if the queue has any messages
    if (queue.Messages > 0)
    {
        Log.Warning("There are {Count} error messages in the queue", queue.Messages);

        // 
        // Logic to pop and handle messages here
        //
    }
    else
    {
        Log.Information("there are no error messages in the error queue");
    }
}
catch (UnexpectedHttpStatusCodeException ex)
{
    Log.Error(ex, "Could not find queue {Queue}", queueName);
}