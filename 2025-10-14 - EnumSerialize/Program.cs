using System.Text.Json;
using System.Text.Json.Serialization;

var cat = new Animal
{
    Name = "Cat",
    AnimalType = AnimalType.Mammal
};

// Setup the serialization to indent the properties
var defaultOptions = new JsonSerializerOptions { WriteIndented = true };

// Get the serialized string
var defaultString = JsonSerializer.Serialize(cat, defaultOptions);

// Print to console
Console.WriteLine(defaultString);

// Deserialize

var deserializedCat = JsonSerializer.Deserialize<Animal>(defaultString, defaultOptions);

// Create our serialization options
var enumStringOptions = new JsonSerializerOptions { WriteIndented = true };
// Add a string enum converter
enumStringOptions.Converters.Add(new JsonStringEnumConverter());
// Serialize
var enumString = JsonSerializer.Serialize(cat, enumStringOptions);
// Print to console
Console.WriteLine(enumString);


var otherCat = JsonSerializer.Deserialize<Animal>(enumString, enumStringOptions);

var whale = new Animal
{
    Name = "Whale",
    AnimalType = AnimalType.VeryLargeMammal
};

// Create our serialization options
var customEnumStringOptions = new JsonSerializerOptions { WriteIndented = true };
// Add a string enum converter in kebab upper case
customEnumStringOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.KebabCaseUpper));

var customEnumString = JsonSerializer.Serialize(whale, customEnumStringOptions);

Console.WriteLine(customEnumString);

Console.ReadLine();