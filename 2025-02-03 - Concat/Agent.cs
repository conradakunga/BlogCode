public sealed record Agent
{
    public required string Name { get; init; }
    public required DateOnly DateOfBirth { get; init; }
}