using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpVerification
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Create  a plain client
            var plainClient = new HttpClient();
            var response = await plainClient.GetStringAsync("http://innova.africa");
            Console.WriteLine(response);

            // Create new client and turn off autoredirect
            var clientAutoOff = new HttpClient(new HttpClientHandler() { AllowAutoRedirect = false });
            response = await clientAutoOff.GetStringAsync("http://innova.africa");
            Console.WriteLine(response);

            // Reuse the previous client, and read just the headers in this request
            var headerResponse = await clientAutoOff.GetAsync("http://innova.africa", HttpCompletionOption.ResponseHeadersRead);
            // Iterate through the headers of the response and print them
            foreach (var item in headerResponse.Headers)
            {
                Console.WriteLine($"Header: {item.Key} - {string.Join(",", item.Value)}");
            }
        }
    }
}
