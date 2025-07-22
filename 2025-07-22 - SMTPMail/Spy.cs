public sealed record Spy
{
    public string Firstname { get; init; }
    public string Surname { get; init; }
    public Gender Gender { get; init; }
    public string EmailAddress { get; init; }
    public DateOnly DateOfBirth { get; set; }
}