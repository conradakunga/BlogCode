using System.Text.Json.Serialization;

public sealed record GitHubUser
{
    [JsonPropertyName("avatar_url")] public required string Avatar { get; init; }
    [JsonPropertyName("name")] public required string Name { get; init; }
    [JsonPropertyName("company")] public required string Company { get; init; }
    [JsonPropertyName("blog")] public required string Blog { get; init; }
    [JsonPropertyName("location")] public required string Location { get; init; }
    [JsonPropertyName("bio")] public required string Bio { get; init; }
    [JsonPropertyName("created_at")] public required DateTime DateCreated { get; init; }
}