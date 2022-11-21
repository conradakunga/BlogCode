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

Log.Information("Serializing using custom options");

// create the options
var options = new JsonSerializerOptions()
{
    WriteIndented = true
};
// register the converter
options.Converters.Add(new NullToEmptyStringConverter());

retrievedMonkey = JsonSerializer.Deserialize<Animal>(rawJson, options);



Console.ReadLine();