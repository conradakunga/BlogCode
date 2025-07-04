using System.Diagnostics;

[DebuggerDisplay("Name: {FullName}; DateOfBirth: {DateOfBirth.ToString(\"d MMM yyyy\")}")]
public sealed class Person
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required DateOnly DateOfBirth { get; init; }
    public string FullName => $"{FirstName} {LastName}";
}