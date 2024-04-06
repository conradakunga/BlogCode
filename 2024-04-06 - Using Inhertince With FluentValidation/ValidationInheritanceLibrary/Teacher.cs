namespace ValidationInheritanceLibrary;

public record Teacher : Person
{
    public required string Subject { get; init; } = null!;
}