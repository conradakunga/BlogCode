// a list of persons
var personList = new List<Person>();

// add multiple people

personList.AddRange(new[] { new Person("James", "Bond"), new Person("Jason", "Bourne") });

// a hashset of persons

var personHashSet = new HashSet<Person>();

// add multiple people

personHashSet.UnionWith(new[] { new Person("Evelyn", "Salt"), new Person("Napoleon", "Solo") });

// add people from existing collection

personHashSet.UnionWith(personList);

foreach (var person in personHashSet)
    Console.WriteLine($"{person.FirstName} {person.Surname}");


public record Person(string FirstName, string Surname);