public sealed class Spy
{
    public Spy(string firstName, string surname, DateOnly dateOfBirth)
    {
        FirstName = firstName;
        Surname = surname;
        DateOfBirth = dateOfBirth;
    }

    public string FirstName { get; }
    public string Surname { get; }
    public DateOnly DateOfBirth { get; }

    public void Deconstruct(out string firstName, out string surname, out DateOnly dateOfBirth)
    {
        firstName = FirstName;
        surname = Surname;
        dateOfBirth = DateOfBirth;
    }
}