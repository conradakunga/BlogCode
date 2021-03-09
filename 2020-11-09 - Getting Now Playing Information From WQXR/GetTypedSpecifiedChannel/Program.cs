using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetTypedSpecifiedChannel
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://api.wnyc.org/api/v1/whats_on/wqxr-special2";

            using (var client = new HttpClient())
            {
                var result = "";

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
                        result = await finalResponse.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine($"Could not get the result, error: {finalResponse.StatusCode}");
                    }
                }
                else
                {
                    // This isn't a redirect. Read the response
                    result = await response.Content.ReadAsStringAsync();
                }

                // Type the response
                var currentItem = JsonConvert.DeserializeObject<Current>(result);

                // Output the results

                var sb = new StringBuilder();

                sb.AppendLine($"The current track playing is: {currentItem?.CurrentPlaylistItem?.CatalogEntry?.Title}");
                sb.AppendLine($"The composer is: {currentItem?.CurrentPlaylistItem?.CatalogEntry?.Composer?.Name}");
                sb.AppendLine($"It is playing on:  {currentItem?.CurrentShow?.Title}");

                Console.Write(sb);

            }
        }
    }
}
