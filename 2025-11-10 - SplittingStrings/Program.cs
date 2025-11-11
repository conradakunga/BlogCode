var input = "This is a string that we want to split";
var splitArray = input.Split(" ");
foreach (var entry in splitArray)
{
    Console.WriteLine($"'{entry}'");
}

// This string has spaces
input = "This is a    string that   we want to   split";
splitArray = input.Split(" ");
foreach (var entry in splitArray)
{
    Console.WriteLine($"'{entry}'");
}

// Split the string with spaces and remove empty elements
splitArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
foreach (var entry in splitArray)
{
    Console.WriteLine($"'{entry}'");
}