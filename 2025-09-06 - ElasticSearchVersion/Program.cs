// using System.Net.Http.Json;
// using ElasticSearchVersion;
//
// var client = new HttpClient();
// const string elasticSearchRoot = "http://localhost:9200/";
//
// var response = await client.GetFromJsonAsync<ElasticSearchResponse>(elasticSearchRoot);
// Console.WriteLine(response!.Version.Number);

using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

var settings = new ElasticsearchClientSettings(new Uri("http://localhost:9200"));
    // .Authentication(new BasicAuthentication("elastic", "YourPassword"))
    // .ServerCertificateValidationCallback((o, c, ch, e) => true); // ignore SSL for testing

var client = new ElasticsearchClient(settings);

var info = await client.InfoAsync();

Console.WriteLine($"Version: {info.Version.Number}");