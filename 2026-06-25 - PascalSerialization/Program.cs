using System.Text.Json;
using PascalSerialization;

var person = new Person
{
    FirstName = "James",
    Surname = "Bond"
};

// Camel case
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true }));
// Kebab case, lower	
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower, WriteIndented = true }));
// Kebab case, upper	
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper, WriteIndented = true }));
// Snake case, lower	
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower, WriteIndented = true }));
// Snake case, upper	
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper, WriteIndented = true }));
// Pascal Case	
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.PascalCase, WriteIndented = true }));