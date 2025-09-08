using System.Text.Json.Serialization;

namespace KibanaVersion;

public sealed class KibanaResponse
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("uuid")] public string UUID { get; set; } = string.Empty;
    [JsonPropertyName("version")] public VersionInfo Version { get; set; } = new();
}