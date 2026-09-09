Person[] people =
[
    new Person("James Bond", new DateOnly(1960, 1, 1), "London", Gender.Male),
    new Person("Harry Pearce", new DateOnly(1955, 1, 1), "Cryodon", Gender.Male),
    new Person("Evelyn Salt", new DateOnly(1960, 1, 1), "Nairobi", Gender.Famale),
    new Person("Vesper Lynd", new DateOnly(1970, 1, 1), "Mombasa", Gender.Famale)
];

foreach (var person in people)
{
    Process(person);
}

return;

void Process(Person person)
{
    if (person.DateOfBirth is { Year: >= 1950 and <= 1965 })
        Console.WriteLine($"{person.FullName} is eligible!");
}

void Process2(Person person)
{
    if (person.DateOfBirth.Year is >= 1950 and <= 1965)
        Console.WriteLine($"{person.FullName} is eligible!");
}

public sealed record Person(string FullName, DateOnly DateOfBirth, string HomeTown, Gender Gender);

public enum Gender
{
    Male,
    Famale
}