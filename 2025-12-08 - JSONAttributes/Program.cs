using System.Text.Json;
using JSONAttributes;

const string json =
    """
    {
      "Firstname": "James",
      "Surname": "Bond"
    }
    """;

var person = JsonSerializer.Deserialize<Person>(json)!;
Console.WriteLine($"Firstname: {person.Firstname}, Surname: {person.Surname}");

const string jsonAttack =
    """
    {
      "Firstname": "James",
      "Surname": "Bond",
      "Surname": "Bourne"
    }
    """;

person = JsonSerializer.Deserialize<Person>(jsonAttack)!;
Console.WriteLine($"Firstname: {person.Firstname}, Surname: {person.Surname}");


var options = new JsonSerializerOptions
{
    AllowDuplicateProperties = false
};

try
{
    person = JsonSerializer.Deserialize<Person>(jsonAttack, options)!;
    Console.WriteLine($"Firstname: {person.Firstname}, Surname: {person.Surname}");
}
catch (JsonException ex)
{
    Console.WriteLine(ex.Message);
}