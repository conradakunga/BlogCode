using Bogus;

var person = new Person
{
    FirstName = "James",
    LastName = "Bond",
    DateOfBirth = new DateOnly(1955, 05, 15),
};

Console.Write($"Created the person {person.FullName}");

var faker = new Faker<Person>()
    .RuleFor(x => x.FirstName, y => y.Name.FirstName())
    .RuleFor(x => x.LastName, y => y.Name.LastName())
    // Date in the past not more than 50 years go
    .RuleFor(x => x.DateOfBirth, y => y.Date.PastDateOnly(50));

var people = faker.Generate(30);

Console.WriteLine($"Generated {people.Count} people");