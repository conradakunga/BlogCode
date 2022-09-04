namespace FunWithDatesAndTimes.Core;
public class Person
{

    public string Surname { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; }
    public DateTime RegistrationDate { get; set; }
}
