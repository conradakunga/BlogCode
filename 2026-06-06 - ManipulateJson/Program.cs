using System.Text.Json;
using System.Text.Json.Nodes;

// Create a ct
var cat = new Cat("Tom", 4);
// Options to indent our json for legibility
var options = new JsonSerializerOptions { WriteIndented = true };
// Serialize
var json = JsonSerializer.Serialize(cat, options);
// Output
Console.WriteLine(json);

// Our new object, based on the old with a change
var amputee = cat with { Legs = 3 };
// Serialize
json = JsonSerializer.Serialize(amputee, options);
Console.WriteLine(json);
// Output

// Create a JonNode
var node = JsonNode.Parse(json);
if (node is null)
    return;
// Read the properties we're interested in
var legs = node["Legs"]?.GetValue<int>();
var name = node["Name"]?.GetValue<string>();
// Output
Console.WriteLine($"{name} has {legs} Legs");

// Mutate some properties
node["Legs"] = 3;
node["Name"] = "Top Cat";

// Get the json from the node
json = node.ToJsonString(options);
// Output
Console.WriteLine(json);

var modifiedCat = JsonSerializer.Deserialize<Cat>(json, options);
Console.WriteLine($"{modifiedCat.Name} has {modifiedCat.Legs} Legs");