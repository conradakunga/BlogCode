using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Serilog;

namespace HttpClientRequest
{
    public static class HttpClientExtensions
    {
        public static async Task<string> MakeRequest(this HttpClient client, string url)
        {
            var formattedResult = "";

            Log.Debug("Requesting {url}", url);

            // Make the initial request
            var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

            // Check if the status code of the response is in the 3xx range
            if (response.IsRedirect())
            {
                // This is a redirect. Make a recursive call
                return await MakeRequest(client, response.Headers.Location.ToString());
            }
            else
            {
                // This isn't a redirect. Read the response
                formattedResult = JToken.Parse(await response.Content.ReadAsStringAsync()).ToString();
            }
            return formattedResult;

        }
    }
}