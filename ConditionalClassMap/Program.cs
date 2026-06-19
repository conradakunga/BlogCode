using System.Globalization;
using Bogus;
using CsvHelper;

var faker = new Faker<Person>()
    .RuleFor(person => person.Gender, faker => faker.PickRandom<Gender>())
    .RuleFor(person => person.FirstName,
        (faker, person) => faker.Name.FirstName(person.Gender == Gender.Male
            ? Bogus.DataSets.Name.Gender.Male
            : Bogus.DataSets.Name.Gender.Female))
    .RuleFor(person => person.LastName, faker => faker.Name.LastName())
    .UseSeed(0);


var people = faker.Generate(20);

// Write all people
{
    // Write csv
    using var writer = new StreamWriter("People.csv");
    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    csv.Context.RegisterClassMap<PersonClassMap>();
    csv.WriteRecords(people);
}
// Write males
{
    var males = people.Where(person => person.Gender == Gender.Male);
    using var writer = new StreamWriter("Male.csv");
    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    csv.Context.RegisterClassMap(new SmartPersonClassMap(Gender.Male));
    csv.WriteRecords(males);
}
// Write females
{
    var females = people.Where(person => person.Gender == Gender.Female);
    using var writer = new StreamWriter("Female.csv");
    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    csv.Context.RegisterClassMap(new SmartPersonClassMap(Gender.Female));
    csv.WriteRecords(females);
}