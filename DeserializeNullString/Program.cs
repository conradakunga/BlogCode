using System.Text.Json;
using DeserializeNullString;
using Serilog;
var rawJson = """
	{
	  "Name": "",
	  "Legs": 4
	}
	""";

Log.Information("Serializing using default options");

var retrievedMonkey = JsonSerializer.Deserialize<Animal>(rawJson);

// create the options
var options = new JsonSerializerOptions()
{
    WriteIndented = true
};
// register the converter
options.Converters.Add(new NullToEmptyStringConverter());

Log.Information("Serializing using custom options");

retrievedMonkey = JsonSerializer.Deserialize<Animal>(rawJson, options);

Console.ReadLine();