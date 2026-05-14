using System.Globalization;
using Bogus;
using CsvHelper;

// Create and configure faker
var faker = new Faker<Spy>()
    .RuleFor(spy => spy.FirstName, faker => faker.Person.FirstName)
    .RuleFor(spy => spy.LastName, faker => faker.Person.LastName)
    .RuleFor(spy => spy.DateOfBirth, faker => DateOnly.FromDateTime(faker.Date.Past(50)))
    .RuleFor(spy => spy.CreationDate, DateTime.Now)
    // This is to make the generated spies static
    .UseSeed(0);

// Generate spies
var spies = faker.Generate(15);
{
    // Write to CSV
    using var writer = new StreamWriter("RawSpies.csv");
    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    csv.WriteRecords(spies);
}

{
    // Write to reordered column csv
    using var writer = new StreamWriter("ColumnOrderedSpies.csv");
    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    csv.Context.RegisterClassMap<SpyClassmap>();
    csv.WriteRecords(spies);
}