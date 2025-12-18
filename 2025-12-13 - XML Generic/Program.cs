using Bogus;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/Generate", () =>
{
    var faker = new Faker<Person>().UseSeed(0)
        .RuleFor(person => person.FirstName, faker => faker.Person.FirstName)
        .RuleFor(person => person.Surname, faker => faker.Person.LastName)
        .RuleFor(person => person.Salary, faker => faker.Random.Decimal(10_000, 99_000));

    return ResultEx.Xml(faker.Generate(5));
});
app.Run();