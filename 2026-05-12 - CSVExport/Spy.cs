public sealed record Spy
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public DateOnly DateOfBirth { get; init; }
    public DateTime CreationDate { get; init; }
}