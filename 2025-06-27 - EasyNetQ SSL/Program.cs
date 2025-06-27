using System.Net.Security;
using EasyNetQ;
using EasyNetQ.DI;
using Newtonsoft.Json;

// Define connection options
const string host = "localhost";
const ushort port = 5671;
const string username = "test";
const string password = "test";

// Create a connection configuration
var connectionConfiguration = new ConnectionConfiguration
{
    Name = host,
    VirtualHost = "/",
    UserName = username,
    Password = password,
    RequestedHeartbeat = TimeSpan.FromMilliseconds(10),
    Port = port
};


// Create a host configuration
var hostConfiguration = new HostConfiguration
{
    Host = host,
    Port = port,
    Ssl =
    {
        //
        // Configure SSL
        //	
        // Set that no SSL errors are permitted
        AcceptablePolicyErrors = SslPolicyErrors.None,
        // Enable SSL
        Enabled = true,
        // Set host
        ServerName = host
    }
};

// Add hosts to the connection configuration
connectionConfiguration.Hosts = new List<HostConfiguration> { hostConfiguration };

// Create bus object
var bus = RabbitHutch.CreateBus(connectionConfiguration,
    serviceRegister =>
    {
        serviceRegister.Register<ISerializer>(_ =>
            new EasyNetQ.JsonSerializer(new JsonSerializerSettings()
                { TypeNameHandling = TypeNameHandling.None }));
    });

bus.SendReceive.Send("Queue", "test");