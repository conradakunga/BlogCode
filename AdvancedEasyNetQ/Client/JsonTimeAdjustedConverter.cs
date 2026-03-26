using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client;

// Essentially parse the date, extract the date, and move it back 6 months
public class JsonTimeAdjustedConverter : JsonConverter<DateTime>
{
    // This is the deserializer
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.Parse(reader.GetString()!, CultureInfo.InvariantCulture).Date.AddMonths(-6);
    }

    // This is the serializer
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
    }
}