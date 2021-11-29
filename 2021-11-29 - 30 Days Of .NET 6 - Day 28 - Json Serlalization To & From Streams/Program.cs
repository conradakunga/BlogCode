using System.Text.Json;

// Create an array of animals
var animals = new[]
{
    new Animal(){ Name = "Dog" , Legs = 4},
    new Animal(){ Name = "Cat" , Legs = 4},
    new Animal(){ Name = "Chicken" , Legs = 2}
};

// Construct the serialization options
var options = new JsonSerializerOptions()
{ WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

// Stream to standard output
using (var stream = Console.OpenStandardOutput())
{
    JsonSerializer.Serialize(stream, animals, options);
}

Console.WriteLine();

// Load the file into a stream
using (var fileStream = new FileStream("animals.json", FileMode.Open))
{
    var newAnimals = JsonSerializer.Deserialize<Animal []>(fileStream, options);
    foreach (var animal in newAnimals)
        Console.WriteLine($"I am {animal.Name} with {animal.Legs} legs");
}
public record Animal
{
    public string Name { get; init; }
    public byte Legs { get; init; }
}