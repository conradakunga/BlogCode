using Bogus;
using SpyLogic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/ListSpies", () =>
{
    // Create and configure our faker
    var spyFaker = new Faker<Spy>();
    spyFaker.RuleFor(x => x.FirstName, (faker) => faker.Name.FirstName());
    spyFaker.RuleFor(x => x.Surname, (faker) => faker.Name.LastName());
    spyFaker.RuleFor(x => x.Age, (faker) => faker.Random.Byte(25, 50));

    // Generate a list of 5 spies
    return spyFaker.Generate(5);
});

app.MapGet("/ListSpiesError", () =>
{
    try
    {
        throw new DivideByZeroException();
    }
    catch (Exception ex)
    {
        return Results.InternalServerError($"There was an error: {ex.Message}");
    }
});

app.Run();