public sealed record Person
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required Gender Gender { get; init; }
}