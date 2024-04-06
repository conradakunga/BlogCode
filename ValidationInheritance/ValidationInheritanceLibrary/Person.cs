namespace ValidationInheritanceLibrary;

public record Person
{
    public required string Name { get; init; } = null!;
    public required DateOnly DateOfBirth { get; init; }
    // Compute the age as difference between birth year and current year
    public int Age => DateOnly.FromDateTime(DateTime.Today).Year - DateOfBirth.Year;
}