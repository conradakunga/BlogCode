using System.Text.Json;

var person = new Person { Name = "James Bond", Age = 40 };
// Configure options for serialization
var options = new JsonSerializerOptions
{
    WriteIndented = true,
    NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.WriteAsString
};
// Serialize
var json = JsonSerializer.Serialize(person, options);
// Print to console
Console.WriteLine(json);