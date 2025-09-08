using StackExchange.Redis;

// Connect to Redis instance
await using var connection =
    await ConnectionMultiplexer.ConnectAsync("localhost:6379,password=YourStrongPassword123");

var db = connection.GetDatabase();

// Run INFO Server command, casting result into a string
var result = (string)(await db.ExecuteAsync("INFO", "Server"))!;

// Extract the elements into a dictionary
var info = result.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
    .Where(line => line.Contains(':')) // only consider attribute lines 
    .Select(line => line.Split(':')) // project into attribute-value
    .ToDictionary(parts => parts[0], parts => parts[1]); // Convert to dictionary

// Fetch the value from the dictionary
Console.WriteLine(info["redis_version"]);