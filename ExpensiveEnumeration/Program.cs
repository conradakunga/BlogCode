string[] people = ["Peter", "Bartholomew", "Matthew", "Simon", "Jude"];

if (people.TryGetNonEnumeratedCount(out var count))
{
    Console.WriteLine($"This is a cheap operation - we got {count}");
}

var complex = Enumerable.Range(1, 50).Where(n => n % 2 == 0);

if (complex.TryGetNonEnumeratedCount(out var _))
{
    Console.WriteLine($"This is a cheap operation");
}
else
{
    Console.WriteLine("This is expensive!");
    //
    // Have our enumeration here
    //
    var result = complex.ToList();

    Console.WriteLine($"There are {result.Count} even numbers");
}