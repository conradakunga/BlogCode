public sealed record Person
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required Genders? Gender { get; init; }
    public DateOnly? DateOfBirth { get; init; }

    public string Salutation => Gender switch
    {
        Genders.Male => "Mr",
        Genders.Female => "Mrs/Miss",
        Genders.Unknown => "Other",
        _ => "Fellow Kenyan"
    };
}