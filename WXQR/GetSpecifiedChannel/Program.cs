using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace GetSpecifiedChannel
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://api.wnyc.org/api/v1/whats_on/wqxr-special2";

            using (var client = new HttpClient(new HttpClientHandler() { AllowAutoRedirect = true }))
            {
                var formattedResult = "";

                // Make the initial request
                var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

                // Check if the status code of the response is in the 3xx range
                if ((int)response.StatusCode >= 300 && (int)response.StatusCode <= 399)
                {
                    // It is a redirect. Extract the location from the header
                    var finalResponse = await client.GetAsync(response.Headers.Location);
                    if (finalResponse.IsSuccessStatusCode)
                    {
                        // Now make the request for the json
                        var jsonResult = await finalResponse.Content.ReadAsStringAsync();
                        // Format the json
                        formattedResult = JToken.Parse(jsonResult).ToString();
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                else
                {
                    // This isn't a redirect. Read the response
                    formattedResult = JToken.Parse(await response.Content.ReadAsStringAsync()).ToString();
                }

                // Output the json
                Console.Write(formattedResult);

            }
        }
    }

}
