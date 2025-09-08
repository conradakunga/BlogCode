using System.Net.Http.Json;
using System.Text.Json;
using Elastic.Clients.Elasticsearch;
using KibanaVersion;

var client = new HttpClient();
const string kibanaRoot = "http://localhost:5601/api/status";

var response = await client.GetFromJsonAsync<KibanaResponse>(kibanaRoot);
Console.WriteLine(response!.Version.Number);

// Get the version by parsing the raw Json
var jsonString = await client.GetStringAsync("http://localhost:5601/api/status");
var json = JsonDocument.Parse(jsonString);
Console.WriteLine($"Version: {json.RootElement.GetProperty("version").GetProperty("number").GetString()}");