using System.Text.Json.Serialization;

namespace V2;

public record Animal
{
    [JsonPropertyOrder(3)]
    public string Name { get; init; }
    [JsonPropertyOrder(2)]
    public byte Legs { get; init; }
    [JsonPropertyOrder(1)]
    public string Sound { get; init; }
}
