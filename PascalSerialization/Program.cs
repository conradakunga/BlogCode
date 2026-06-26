using System.Text.Json;
using PascalSerialization;

var person = new Person
{
    FirstName = "James",
    Surname = "Bond"
};

// Camel case
Console.WriteLine("Camel Case");
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true }));
// Kebab case, lower	
Console.WriteLine("Kebab Case, Lower");
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower, WriteIndented = true }));
// Kebab case, upper	
Console.WriteLine("Kebab Case, Uppter");
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper, WriteIndented = true }));
// Snake case, lower	
Console.WriteLine("Snake Case, Lower");
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower, WriteIndented = true }));
// Snake case, upper	
Console.WriteLine("Snake Case, Upper");
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper, WriteIndented = true }));
// Pascal Case	
Console.WriteLine("Pascal Case");
Console.WriteLine(JsonSerializer.Serialize(person,
    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.PascalCase, WriteIndented = true }));