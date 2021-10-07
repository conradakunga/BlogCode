using System.Net;

// Create a handler to turn off SSL validation
var httpClientHandler = new HttpClientHandler();
httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
{
    return true;
};

// Create a new HttpClient and wire it to our handler
var client = new HttpClient(httpClientHandler)
    {
        // Specify that requests should be for HTTP/3
        DefaultRequestVersion = HttpVersion.Version3o0,
        DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
    };


// Get our response
var response = await client.GetAsync("https://localhost:5001/");
// Read the body
var body = await response.Content.ReadAsStringAsync();


// Print the relevant headers to verify our results
Console.WriteLine($"HTTP Version: {response.Version}");
Console.WriteLine($"Status: {response.StatusCode}");
Console.WriteLine($"Body: {body}");
