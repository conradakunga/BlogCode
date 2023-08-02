using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;
using Refit;

var engine = new Engine();
var response = await engine.GetPerson("3234");


Console.WriteLine(JsonSerializer.Serialize(response));


public interface IEngine
{
    [Get("/{idNumber}")]
    Task<Person> GetPerson(string idNumber);
}
public class Engine
{
    IEngine api;
    public Engine()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };
        var settings = new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(options),

        };
        api = RestService.For<IEngine>("http://localhost:5177", settings);
    }
    public async Task<Person> GetPerson(string idNumber)
    {

        var res = await api.GetPerson(idNumber);
        return res;
    }
}
public class Person
{
    public string Name { get; set; } = default!;
    public byte Age { get; set; }
}
