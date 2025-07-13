using EasyNetQ.Management.Client;
using Serilog;

async Task Main()
{
    // Configure logging
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

    // Fetch / configure access parameters
    var username = "test";
    var password = "test";
    var hostAddress = "localhost";
    var adminPort = 15672;
    var queueName = "ClientUnitizationResponse_HERACLES";

    Log.Information("Connecting to {Host} on Port {Port}", hostAddress, adminPort);
    // Create a management client
    var mc = new ManagementClient(new Uri($"http://{hostAddress}:{adminPort}"), username, password);
    try
    {
        // Fetch the queue form the default vHost
        var queue = await mc.GetQueueAsync("/", queueName);

        // Delete the queue
        Log.Information("Deleting {Queue} ...", queue.Name);
        await mc.DeleteQueueAsync(queue.Vhost, queue.Name);

        Log.Information("Deleted {Queue}", queue.Name);
    }
    catch (UnexpectedHttpStatusCodeException ex)
    {
        Log.Error(ex, "Could not find queue {Queue}", queueName);
    }
}