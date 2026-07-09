using System.Net;

// Write a handler to configure compression
var handler = new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.Zstandard
};

// Setup the httpClient
var client = new HttpClient(handler);

// Fetch the response
var response = await client.GetStringAsync("https://facebook.com");

Console.WriteLine(response.Length);