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

// Loop through and print the name and type

PrintPropertyValues(serverProperties, 0);
return;

void PrintPropertyValues(IDictionary<string, object> properties, int indent)
{
    // Loop through each element in the key-value pair
    foreach (var property in properties)
    {
        // Generate padding for each value
        var prefix = new string(' ', indent * 2);

        // Check the value type
        switch (property.Value)
        {
            case byte[] bytes:
                Console.WriteLine($"{prefix}{property.Key} - {Encoding.UTF8.GetString(bytes)}");
                break;
            case IDictionary<string, object> nested:
                Console.WriteLine($"{prefix}{property.Key} :");
                PrintPropertyValues(nested, indent + 1);
                break;
            default:
                Console.WriteLine($"{prefix}{property.Key} - {property.Value.ToString()}");
                break;
        }
    }
}