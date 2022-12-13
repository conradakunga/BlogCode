using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

var options = new JsonSerializerOptions();
options.Converters.Add(new JsonNullableDateOnlyConverter());

const string jsonBond = """
{
    "name": "James Bond",
    "birthday": "1950 01 28"
}
""";
const string jsonSalt = """
{
    "name": "Evelyn Salt",
    "birthday": "0000 00 00"
}
""";
const string jsonBourne = """
{
    "name": "Jason Bourne",
    "birthday": "null"
}
""";
const string jsonEnglish = """
{
    "name": "Johnny English",
    "birthday": null
}
""";
var bond = JsonSerializer.Deserialize<Person>(jsonBond, options);
var salt = JsonSerializer.Deserialize<Person>(jsonSalt, options);
var bourne = JsonSerializer.Deserialize<Person>(jsonBourne, options);
var english = JsonSerializer.Deserialize<Person>(jsonEnglish, options);
var agents = new[] { bond, salt, bourne, english };
foreach (var agent in agents)
{
    Console.WriteLine(
        $"{agent.Name} was born on {(agent.Birthday.HasValue ? $"{agent.Birthday.Value:d MMM yyyy}" : " an unknown date")}");
}

public class Person
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("birthday")] public DateOnly? Birthday { get; set; }
}

public class JsonDateOnlyConverter : JsonConverter<DateOnly>
{
    // Define the date format the data is in
    private const string DateFormat = "yyyy MM dd";

    // This is the deserializer
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString()!,
            DateFormat);
    }

    // This is the serializer
    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(
            DateFormat, CultureInfo.InvariantCulture));
    }
}

public class JsonNullableDateOnlyConverter : JsonConverter<DateOnly?>
{
    // Define the date format the data is in
    private const string DateFormat = "yyyy MM dd";

    // This is the deserializer
    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var input = reader.GetString();
        if (!string.IsNullOrEmpty(input) && input != "null" && input != "0000 00 00")
            return DateOnly.ParseExact(reader.GetString()!,
                DateFormat);
        else
        {
            return null;
        }
    }

    // This is the serializer
    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString(
                DateFormat, CultureInfo.InvariantCulture));
    }
}