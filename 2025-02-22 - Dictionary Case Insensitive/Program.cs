// Create a dictionary with a string key that stores integers

var dict = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
// Add an item to the dictionary
dict.Add("James", 50);
dict.Add("Eve", 25);
dict.Add("Vesper", 35);

// Print sample name to console
Console.WriteLine(dict["James"]);
// Capture input from user
Console.WriteLine("Enter name of agent to search");

var name = Console.ReadLine();
// Print the value
if (!string.IsNullOrEmpty(name))
{
    Console.WriteLine($"You entered {name} and we found {dict[name]}");
}
else
    Console.WriteLine("Please enter a name");