using System.Text.Json;
using System.Text.Json.Serialization;

var cat = new Animal() { Name = "Cat", Legs = 4 };
cat.Parent = cat;

Console.WriteLine($"This is a {cat.Name} and it's parent is {cat.Parent.Name}");

var options = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.Preserve };
var serializedString = JsonSerializer.Serialize(cat, options);

Console.WriteLine(serializedString);

options = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles };
serializedString = JsonSerializer.Serialize(cat, options);

Console.WriteLine(serializedString);



