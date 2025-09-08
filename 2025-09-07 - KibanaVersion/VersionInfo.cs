using System.Text.Json.Serialization;

namespace KibanaVersion;

public sealed class VersionInfo
{
    [JsonPropertyName("build_date")] public DateTime BuildDate { get; set; }

    [JsonPropertyName("build_flavor")] public string BuildFlavor { get; set; } = string.Empty;

    [JsonPropertyName("build_hash")] public string BuildHash { get; set; } = string.Empty;

    [JsonPropertyName("build_number")] public int BuildNumber { get; set; }

    [JsonPropertyName("build_snapshot")] public bool BuildSnapshot { get; set; }

    [JsonPropertyName("number")] public string Number { get; set; } = string.Empty;
}