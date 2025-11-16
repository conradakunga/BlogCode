using System.Text.Json;

var person = new Person { Name = "James Bond", Age = 40 };
// Configure options for serialization
var options = new JsonSerializerOptions
{
    WriteIndented = true
};
// Serialize
var json = JsonSerializer.Serialize(person, options);
// Print to console
Console.WriteLine(json);

var apiJson =
    """
    {
      "Name": "James Bond",
      "Age": "40"
    }
    """;
// Configure options for deserialization
var serializationOptions = new JsonSerializerOptions
{
    NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
};
// Deserialize to an object
person = JsonSerializer.Deserialize<Person>(apiJson, serializationOptions)!;
// Print details
Console.WriteLine($"{person.Name} is {person.Age} years old");