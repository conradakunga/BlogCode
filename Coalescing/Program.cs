{
    var spy = new Spy { FirstName = "James", Surname = "Bond" };

    Console.WriteLine(spy);

    if (spy.MiddleName is null)
    {
        spy.MiddleName = "Matthew";
    }

    Console.WriteLine(spy);
}
{
    var spy = new Spy { FirstName = "James", Surname = "Bond" };

    Console.WriteLine(spy);

    spy.MiddleName ??= "Matthew";

    Console.WriteLine(spy);
}


public sealed record Spy
{
    public required string FirstName { get; init; }
    public string? MiddleName { get; set; }
    public required string Surname { get; init; }
}