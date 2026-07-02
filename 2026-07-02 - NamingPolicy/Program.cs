using System.Text.Json;

var oldSpy = new V1.Spy
{
    FirstName = "James",
    Surname = "Bond",
    DateOfBirth = new DateOnly(1950, 1, 1)
};

var oldOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
};
var newSpy = new V2.Spy
{
    FirstName = "James",
    Surname = "Bond",
    DateOfBirth = new DateOnly(1950, 1, 1)
};

var newOptions = new JsonSerializerOptions
{
    WriteIndented = true,
};

Console.WriteLine(JsonSerializer.Serialize(oldSpy, oldOptions));
Console.WriteLine(JsonSerializer.Serialize(newSpy, newOptions));