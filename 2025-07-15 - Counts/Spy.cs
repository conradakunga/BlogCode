public sealed record Spy
{
    public required string Firstname { get; init; }
    public required string Surmame { get; init; }
    public required DateOnly DateOfBirth { get; init; }
}