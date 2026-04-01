var person = new Person()
{
    ID = 1,
    FirstName = "James",
    Surname = "Bond"
};

Console.WriteLine("Hello, World!");

public sealed record Person
{
    public required int ID { get; init; }
    public required string FirstName { get; init; }
    public required string Surname { get; init; }
}