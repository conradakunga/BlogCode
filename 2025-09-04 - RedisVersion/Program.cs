// Adjust your connection string as needed

using StackExchange.Redis;

// Get a connection to the Redis server
await using (var connection =
             await ConnectionMultiplexer.ConnectAsync("localhost:6379,password=YourStrongPassword123,allowAdmin=true"))
{
    // Retrieve the server
    var server = connection.GetServer("localhost", 6379);

    // Execute the INFO command
    var version = server.Info("Server")
        .SelectMany(g => g)
        .FirstOrDefault(p => p.Key == "redis_version").Value;

    Console.WriteLine($"Redis Version: {version}");
}