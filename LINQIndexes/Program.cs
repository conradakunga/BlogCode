string[] names =
[
    "Brenda", "Latisha", "Linda", "Felicia", "Dawn", "LeShaun", "Ines", "Alicia", "Teresa", "Monica", "Sharon", "Nicki",
    "Lisa", "Veronica", "Karen", "Vicky", "Cookie", "Tonya", "Diane", "Lori", "Carla", "Marina", "Selena", "Katrina",
    "Sabrina", "Kim", "LaToya", "Tina", "Shelley", "Bridget", "Cathy", "Rasheeda", "Kelly", "Nicole", "Angel",
    "Juanita", "Stacy", "Tracie", "Rohna", "Ronda", "Donna", "Yolanda", "Tawana", "Wanda",
];

for (var i = 0; i < names.Length; i++)
{
    Console.WriteLine($"{names[i]} is item {i}");
}

var everyOtherName = new List<string>();

for (var i = 0; i < names.Length; i++)
{
    if (i % 2 == 0)
        everyOtherName.Add(names[i]);
}

everyOtherName.ForEach(Console.WriteLine);

var namesWithIndexes = names.Index().ToList();
namesWithIndexes.ForEach(element =>
    Console.WriteLine($"{element.Item} is index {element.Index}"));

var otherNamesWithIndexes = names.Select((element, index) =>
    new { Name = element, Index = index }).ToList();
otherNamesWithIndexes.ForEach(element =>
    Console.WriteLine($"{element.Name} is index {element.Index}"));


var filteredVictorious = names.Where((element, index) =>
    // Filter names with length greater than 5 and then
    // pick the even ones based on the modulus division of
    // the index
    element.Length > 5 && index % 2 == 0).ToList();
// Print to console
filteredVictorious.ForEach(Console.WriteLine);