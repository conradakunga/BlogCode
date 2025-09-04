using System.Text;
using RabbitMQ.Client;

// Set the username, password & port
const string username = "test";
const string password = "test";
const short port = 5672;

// Create factory to use for connection
var factory = new ConnectionFactory
{
    Uri = new Uri($"amqp://{username}:{password}@localhost:{port}/")
};

// Get a connection
using var connection = factory.CreateConnection();

// Fetch the server properties
var serverProperties = connection.ServerProperties;

// Fetch the version
if (serverProperties.TryGetValue("version", out var versionBytes))
{
    // Decode the version
    var version = Encoding.UTF8.GetString((byte[])versionBytes);

    // Print version info
    Console.WriteLine($"RabbitMQ Version: {version}");
}
else
{
    Console.WriteLine("Error fetching version");
}