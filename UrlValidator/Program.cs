using System;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog;

namespace UrlValidator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new LoggerConfiguration();
            config.MinimumLevel.Debug();
            config.WriteTo.Console();

            Log.Logger = config.CreateLogger();
            var url = "https://www.dnsstuff.com";
            var client = new HttpClient();

			// Set the default user-agent header
            client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36");

            var res = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            var response = res.IsSuccessStatusCode;
            Log.Information("The response for {url} is {response}", url, response);

            // Log the returned status code
            Log.Information("The returned status code for {url} is {code}", url, res.StatusCode);
        }
    }
}
