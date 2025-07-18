using Bogus;
using Humanizer;

var faker = new Faker<Spy>()
    // Use a fixed seed
    .UseSeed(0)
    // Configure first name
    .RuleFor(s => s.Firstname, t => t.Person.FirstName)
    // Configure surname
    .RuleFor(s => s.Surmame, t => t.Person.LastName)
    // Set date of birth is 50 years in the past max
    .RuleFor(s => s.DateOfBirth, t => DateOnly.FromDateTime(t.Date.Past(50)));

// Generate 15

var spies = faker.Generate(15);

Console.WriteLine($"{spies.Count} spies were generated");

Console.WriteLine($"{GetCount(spies.Count)} generated");

Console.WriteLine($"{"spy".ToQuantity(spies.Count)} generated");

// Generate 1

spies = faker.Generate(1);

Console.WriteLine($"{spies.Count} spies were generated");

Console.WriteLine($"{GetCount(spies.Count)} generated");

Console.WriteLine($"{"spy".ToQuantity(spies.Count)} generated");

// Generate none

spies = faker.Generate(0);

Console.WriteLine($"{GetCount(spies.Count)} generated");

Console.WriteLine($"{"spy".ToQuantity(spies.Count)} generated");
return;

string GetCount(int count) => count switch
{
    // Zero returns
    0 => "No spies were",
    // One return
    1 => "One spy was",
    // Any other result
    _ => $"{count} spies were"
};