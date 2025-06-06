namespace SpyLogic;

public sealed record Spy
{
    public required string FirstName { get; init; }
    public required string Surname { get; init; }
    public required byte Age { get; init; }
}