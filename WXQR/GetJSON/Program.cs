using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace GetJSON
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://api.wnyc.org/api/v1/whats_on/");
                var formattedResponse = JToken.Parse(response).ToString();
                Console.Write(formattedResponse);
            }
        }
    }
}
