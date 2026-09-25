using System.Globalization;
using Bogus;
using CsvHelper;
using CsvHelper.Configuration;

var faker = new Faker<Spy>()
    .RuleFor(x => x.Firstname, f => f.Name.FirstName())
    .RuleFor(x => x.Lastname, f => f.Name.LastName())
    .RuleFor(x => x.DateOfBirth, f => f.Date.PastDateOnly(50));

var spies = faker.Generate(10);

// Configure the generation
var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    // Set our delimiter
    Delimiter = "|"
};
// Write to file
using (var writer = new StreamWriter("spies.csv"))
{
    using (var csv = new CsvWriter(writer, config))
    {
        csv.WriteRecords(spies);
    }
}