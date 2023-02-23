using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace GetJSON
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
                var response = await client.GetStringAsync("https://api.wnyc.org/api/v1/whats_on/");
                var formattedResponse = JsonDocument.Parse(response);
                Console.Write(JsonSerializer.Serialize(formattedResponse, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
