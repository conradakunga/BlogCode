namespace v2;
public class Person
{
    public string FirstName { get; }
    public string Surname  { get; }

    private Person() { }
    public Person(string firstName, string surname) => (FirstName, Surname) = (firstName, surname);
}
