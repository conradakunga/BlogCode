using System.Text.Json.Serialization;

namespace V4;

public record Animal
{
	public string Name { get; init; }
	[JsonPropertyOrder(2)]
	public byte Legs { get; init; }
	[JsonPropertyOrder(1)]
	public string Sound { get; init; }
	public string Color { get; init; }
	[JsonPropertyOrder(-1)]
	public Guid ID { get; init; }
}
