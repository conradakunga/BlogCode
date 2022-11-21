using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeserializeNullString;

public class NullToEmptyStringConverter : JsonConverter<string>
{
    // Override default null handling
    public override bool HandleNull => true;

    // Check the type
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(string);
    }

    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Read the string
        var res = reader.GetString();
        // If it is am empty string, return a null
        if (string.IsNullOrEmpty(res))
            return null;
        else
            // otherwise, return the read value
            return res;
    }

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        if (value == null)
            writer.WriteStringValue("");
        else
            writer.WriteStringValue(value);
    }
}