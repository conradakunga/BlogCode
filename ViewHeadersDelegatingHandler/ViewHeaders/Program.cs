using Serilog;
using ViewHeaders;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var client = new HttpClient(new ViewHeadersDelegatingHandler());
// Set the user agent because some servers reject requests without one
client.DefaultRequestHeaders.Add("User-Agent",
    "Mozilla/5.0 (Macintosh; Intel Mac OS X 14.5; rv:42.0) Gecko/20100101 Firefox/42.0");

string[] urls =
[
    "https://www.booking.com",
    "https://www.conradakunga.com",
    "https://www.gigaom.com",
    "https://www.newsblur.com",
    "https://www.wordpress.com",
];
// Make a GET request
foreach (var url in urls)
{
    _ = await client.GetAsync(url);
}