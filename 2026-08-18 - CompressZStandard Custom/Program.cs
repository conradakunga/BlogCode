using System.IO.Compression;
using System.Net;

const string API_URL = "https://reqbin.com/echo/post/json";

var jamesBond = new Spy
{
    Firstname = "James",
    Surname = "Bond",
    Agency = "MI-6",
    DateOfBirth = new DateOnly(1950, 1, 1),
    HireDate = new DateOnly(1975, 1, 1)
};

var handler = new HttpClientHandler
{
    AutomaticDecompression = DecompressionMethods.Zstandard
};

var client = new HttpClient(handler);
await client.PostAsJsonAsync(API_URL, jamesBond);

// Create the payload
var payload = JsonContent.Create(jamesBond);
// Create a HttpRequest
using var request = new HttpRequestMessage(HttpMethod.Post, API_URL);
// Set-up compression options
var options = new ZstandardCompressionOptions
{
    Quality = 6,
    AppendChecksum = true,
    EnableLongDistanceMatching = false
};
// Compress the content
request.Content = new ZstandardCompressedContent(payload, options);
//Post
await client.SendAsync(request);