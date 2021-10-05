using System.Net;

// Create a handler for socks connectivity.
// Note the URI starts with socks5
var socksHander = new HttpClientHandler
{
    Proxy = new WebProxy("socks5://127.0.0.1", 9050)
};
// Wire the handler to a new http client
var client = new HttpClient(socksHander);

// Make a request

var response = await client.GetAsync("https://google.com");