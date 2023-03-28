const string names = """
Madonna
Salma Hayek
Robyn Fenty Rihanna
Jennifer Lawrence Shrader
Julia Louis-Dreyfus Scarlett Elizabeth 
""";

var nameList = names.Split(Environment.NewLine);
foreach (var name in nameList)
{
    var person = name.Split(" ") switch
    {
        // Check if the string array has a single element
        [var firstName] => new Actress() { Firstname = firstName },
        // Check if the string array has two elements
        [var firstName, var surname] => new Actress() { Firstname = firstName, Surname = surname },
        // Check if the string array has three elements
        [var firstName, var surname, var middleName] => new Actress() { Firstname = firstName, Surname = surname, Middlename = middleName },
        // Catch all for greater than 3 names
        [var firstName, var surname, .. var middleNames,] => new Actress() { Firstname = firstName, Surname = surname, Middlename = string.Join(" ", middleNames) },
        _ => throw new Exception()
    };
    Console.WriteLine(person);
}

public record Actress
{
    // Firstname should never be null
    public string Firstname { get; init; } = default!;
    public string? Middlename { get; init; }
    public string? Surname { get; init; }
}