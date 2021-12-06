using System.Text;
using System.Text.Json;

var animals = new[]
{
    new Animal(){ Name = "Octopus" , Legs = 8},
    new Animal(){ Name = "Octopus Plus" , Legs = 10},
};

// Stream to standard output
var options = new JsonSerializerOptions() { WriteIndented = true };
using (var stream = Console.OpenStandardOutput())
{
    JsonSerializer.Serialize(stream, animals, options);

    var writeOptions = new JsonWriterOptions() { Indented = true };

    // Create a Utf8Json writer, and configure it to indent
    using (var writer = new Utf8JsonWriter(stream, writeOptions))
    {
        writer.WriteStartObject();
        writer.WriteStartArray("Animals");
        foreach (var animal in animals)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(animal.Name));
            writer.WriteStringValue(animal.Name);
            writer.WritePropertyName(nameof(animal.Legs));
            // Covert to octal wand write
            writer.WriteNumberValue(ConvertToOctal(animal.Legs));
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
    }


    // Create a Utf8Json writer, and configure it to indent
    using (var writer = new Utf8JsonWriter(stream, writeOptions))
    {
        writer.WriteStartObject();
        writer.WriteStartArray("Animals");
        foreach (var animal in animals)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(animal.Name));
            writer.WriteStringValue(animal.Name);
            writer.WritePropertyName(nameof(animal.Legs));
            // Covert to octal and write
            writer.WriteRawValue(ConvertToOctalForJson(animal.Legs), skipInputValidation: true);
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
    }
}

int ConvertToOctal(int number)
{
    // Convert the number to a string (in octal) and then
    // parse it back to a number
    return int.Parse(Convert.ToString(number, 8));
}
string ConvertToOctalForJson(int number)
{
    // Convert the number to a string (in octal), and format it
    return $"0{Convert.ToString(number, 8)}";
}