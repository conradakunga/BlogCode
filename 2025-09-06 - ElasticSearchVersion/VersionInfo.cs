using System.Text.Json.Serialization;

namespace ElasticSearchVersion;

public sealed class VersionInfo
{
    [JsonPropertyName("number")] public string Number { get; set; } = string.Empty;
    [JsonPropertyName("build_flavor")] public string BuildFlavor { get; set; } = string.Empty;
    [JsonPropertyName("build_type")] public string BuildType { get; set; } = string.Empty;
    [JsonPropertyName("build_hash")] public string BuildHash { get; set; } = string.Empty;
    [JsonPropertyName("build_date")] public DateTime BuildDate { get; set; }
    [JsonPropertyName("build_snapshot")] public bool BuildSnapshot { get; set; }
    [JsonPropertyName("lucene_version")] public string LuceneVersion { get; set; } = string.Empty;

    [JsonPropertyName("minimum_wire_compatibility_version")]
    public string MinimumWireCompatibilityVersion { get; set; } = string.Empty;

    [JsonPropertyName("minimum_index_compatibility_version")]
    public string MinimumIndexCompatibilityVersion { get; set; } = string.Empty;
}