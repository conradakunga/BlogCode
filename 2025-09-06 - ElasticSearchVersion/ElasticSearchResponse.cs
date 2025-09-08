using System.Text.Json.Serialization;

namespace ElasticSearchVersion;

public sealed class ElasticSearchResponse
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("cluster_name")] public string ClusterName { get; set; } = string.Empty;
    [JsonPropertyName("cluster_uuid")] public string ClusterUuid { get; set; } = string.Empty;
    [JsonPropertyName("version")] public VersionInfo Version { get; set; } = new();
    [JsonPropertyName("tagline")] public string Tagline { get; set; } = string.Empty;
}