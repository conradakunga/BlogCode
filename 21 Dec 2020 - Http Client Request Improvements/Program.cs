using System;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog;

namespace HttpClientRequest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new LoggerConfiguration();
            config.MinimumLevel.Debug();
            config.WriteTo.Console();

            Log.Logger = config.CreateLogger();

            using (var client = new HttpClient())
            {
                // Output the json
                Console.Write(await client.MakeRequest("https://api.wnyc.org/api/v1/whats_on/wqxr-special2"));
            }
        }
    }
}
