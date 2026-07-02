using System.Text.Json.Serialization;

namespace V1
{
    public sealed class Spy
    {
        public required string FirstName { get; init; }

        public required string Surname { get; init; }

        public required DateOnly DateOfBirth { get; init; }
    }
}

namespace V2
{
    public sealed class Spy
    {
        [JsonNamingPolicy(JsonKnownNamingPolicy.SnakeCaseLower)]
        public required string FirstName { get; init; }

        [JsonNamingPolicy(JsonKnownNamingPolicy.CamelCase)]
        public required string Surname { get; init; }

        [JsonNamingPolicy(JsonKnownNamingPolicy.CamelCase)]
        public required DateOnly DateOfBirth { get; init; }
    }
}