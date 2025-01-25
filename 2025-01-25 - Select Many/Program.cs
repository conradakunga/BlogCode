Person[] people =
[
    new Person { Name = "Stacy", Hobbies = ["Fishing", "Hunting"] },
    new Person { Name = "Tracy", Hobbies = ["Boxing", "Shooting"] },
    new Person { Name = "Rohna", Hobbies = ["Painting", "Shooting"] },
    new Person { Name = "Ronda", Hobbies = ["Diving", "Snorkeling"] },
    new Person { Name = "Donna", Hobbies = ["Poetry", "Archery"] },
    new Person { Name = "Yolanda", Hobbies = ["Gaming"] },
    new Person { Name = "Tawana", Hobbies = ["Jogging", "Basketball"] },
    new Person { Name = "Wanda", Hobbies = ["Karate", "Judo"] },
];

var names = people.Select(x => x.Name).ToArray();
foreach (var name in names)
    Console.WriteLine(name);

var allHobbies = people.Select(x => x.Hobbies).ToArray();
foreach (var hobby in allHobbies)
{
    foreach (var personalHobby in hobby)
    {
        Console.WriteLine(personalHobby);
    }
}

var hobbies = people.SelectMany(x => x.Hobbies).ToArray();
foreach (var hobby in hobbies)
{
    Console.WriteLine(hobby);
}

var results = people.SelectMany(p => p.Hobbies,
    (person, hobby) =>
        new { PersonName = person.Name, Hobby = hobby }).ToArray();

foreach (var result in results)
    Console.WriteLine($"{result.Hobby} is a hobby of {result.PersonName}");