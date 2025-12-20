using System.Net.Mime;
using Bogus;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/Generate", async (HttpRequest request) =>
{
    var faker = new Faker<Person>().UseSeed(0)
        .RuleFor(person => person.FirstName, faker => faker.Person.FirstName)
        .RuleFor(person => person.Surname, faker => faker.Person.LastName)
        .RuleFor(person => person.Salary, faker => faker.Random.Decimal(10_000, 99_000));

    var people = faker.Generate(5).ToList();
    // Get the request header
    var header = request.Headers.Accept.ToString();
    // Check if XML was requested
    if (header.Contains(MediaTypeNames.Application.Xml, StringComparison.OrdinalIgnoreCase))
        return await Results.Xml(people);
    // Return JSON otherwise
    return Results.Ok(people);
});
app.Run();