using System.Net;
using System.Net.Sockets;

// Get the IPAddresses for the domain
var result = await Dns.GetHostAddressesAsync("conradakunga.com");
Console.WriteLine($"There were {result.Length} address(es) found");
// Cycle through and print the results
foreach (var address in result)
    Console.WriteLine(address);


// Get the IPAddresses for the domain
result = await Dns.GetHostAddressesAsync("google.com");
Console.WriteLine($"There were {result.Length} address(es) found");
// Cycle through and print the results
foreach (var address in result)
    Console.WriteLine(address);

var domain = await Dns.GetHostEntryAsync("69.163.186.112");
Console.WriteLine($"The host for this domain is {domain.HostName}");

const string whoisServer = "whois.verisign-grs.com";

using (var client = new TcpClient(whoisServer, 43))
await using (var stream = client.GetStream())
await using (var writer = new StreamWriter(stream))
using (var reader = new StreamReader(stream))
{
    await writer.WriteLineAsync("conradakunga.com");
    await writer.FlushAsync();

    // Read only the first line from the response.
    string response = (await reader.ReadLineAsync())!;
    Console.WriteLine(response);
}