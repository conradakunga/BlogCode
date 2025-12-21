using System.Globalization;
using System.Text;
using Bogus;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptions<Settings>()
    .Bind(builder.Configuration.GetSection(nameof(Settings)))
    .ValidateDataAnnotations()
    .ValidateOnStart();

// Authentication - the exact scheme does not matter for this example!
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://fake-provider.com";
        options.Audience = "api";
    });
builder.Services.AddAuthorization();

var app = builder.Build();
app.UseAuthorization();

// Create a group for all routes, and set to require authentication
var secured = app.MapGroup("")
    .RequireAuthorization();

secured.MapGet("/v1/Generate", () =>
{
    var faker = new Faker<Person>().UseSeed(0)
        .RuleFor(person => person.FirstName, faker => faker.Person.FirstName)
        .RuleFor(person => person.Surname, faker => faker.Person.LastName)
        .RuleFor(person => person.Salary, faker => faker.Random.Decimal(10_000, 99_000));
    var sb = new StringBuilder();
    foreach (var person in faker.Generate(10).ToList())
    {
        sb.AppendLine($"| {person.FirstName} | {person.Surname} | {person.Salary.ToString("0.00")} |");
    }

    return Results.Text(sb.ToString());
});

secured.MapGet("/v2/Generate", () =>
{
    var french = new CultureInfo("fr-FR");
    var faker = new Faker<Person>().UseSeed(0)
        .RuleFor(person => person.FirstName, faker => faker.Person.FirstName)
        .RuleFor(person => person.Surname, faker => faker.Person.LastName)
        .RuleFor(person => person.Salary, faker => faker.Random.Decimal(10_000, 99_000));
    var sb = new StringBuilder();
    foreach (var person in faker.Generate(10).ToList())
    {
        sb.AppendLine($"| {person.FirstName} | {person.Surname} | {person.Salary.ToString("0,0.00", french)} |");
    }

    return Results.Text(sb.ToString());
});

secured.MapGet("/v3/Generate", (IOptions<Settings> options) =>
{
    var settings = options.Value;
    // We are cloning an existing one instead of creating a new one
    // to avoid the need to specify all the settings.
    var numberFormatInfo = (NumberFormatInfo)
        CultureInfo.InvariantCulture.NumberFormat.Clone();
    // Set the formats
    numberFormatInfo.NumberDecimalSeparator = settings.DecimalSeparator;
    numberFormatInfo.NumberGroupSeparator = settings.ThousandSeparator;
    var faker = new Faker<Person>().UseSeed(0)
        .RuleFor(person => person.FirstName, faker => faker.Person.FirstName)
        .RuleFor(person => person.Surname, faker => faker.Person.LastName)
        .RuleFor(person => person.Salary, faker => faker.Random.Decimal(10_000, 99_000));
    var sb = new StringBuilder();
    foreach (var person in faker.Generate(10).ToList())
    {
        sb.AppendLine(
            $"| {person.FirstName} | {person.Surname} | {person.Salary.ToString("0,0.00", numberFormatInfo)} |");
    }

    return Results.Text(sb.ToString());
});

secured.MapGet("/Health", () => Results.Ok()).AllowAnonymous();
app.Run();