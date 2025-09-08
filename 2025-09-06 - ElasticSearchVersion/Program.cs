using System.Net.Http.Json;
using ElasticSearchVersion;
using Elastic.Clients.Elasticsearch;

var client = new HttpClient();
const string elasticSearchRoot = "http://localhost:9200/";

var response = await client.GetFromJsonAsync<ElasticSearchResponse>(elasticSearchRoot);
Console.WriteLine(response!.Version.Number);


var settings = new ElasticsearchClientSettings(new Uri("http://localhost:9200"));
// .Authentication(new BasicAuthentication("elastic", "YourPassword"))
// .ServerCertificateValidationCallback((o, c, ch, e) => true); // ignore SSL for testing

var elasticsearchClient = new ElasticsearchClient(settings);

var info = await elasticsearchClient.InfoAsync();

Console.WriteLine($"Version: {info.Version.Number}");