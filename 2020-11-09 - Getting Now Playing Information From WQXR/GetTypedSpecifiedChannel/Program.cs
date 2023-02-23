using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Serilog;

namespace GetTypedSpecifiedChannel
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();;

            var client = new HttpClient();
            var result = "";

            var url = "https://api.wnyc.org/api/v1/whats_on/wqxr-special2";

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
                    Log.Error("Could not get the result, {Error}: {finalResponse.StatusCode}");
                }
            }
            else
            {
                // This isn't a redirect. Read the response
                result = await response.Content.ReadAsStringAsync();
            }
            // Type the response
            var currentItem = JsonSerializer.Deserialize<Current>(result);

            // Output the results
            Log.Information("The current track playing is: {Track}", currentItem?.CurrentPlaylistItem?.CatalogEntry?.Title);
            Log.Information("The composer is: {Composer}", currentItem?.CurrentPlaylistItem?.CatalogEntry?.Composer?.Name);
            Log.Information("It is playing on: {Show}", currentItem?.CurrentShow?.Title);
        }
    }
}
