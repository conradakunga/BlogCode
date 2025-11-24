try
{
    Parallel.For(0, 3, i =>
    {
        // Throw a known exception
        throw new InvalidOperationException("Some invalid thing happened");
    });
}
catch (AggregateException ex)
{
    Console.WriteLine("There were {0} exceptions ", ex.InnerExceptions.Count);

    var counter = 0;
    foreach (var e in ex.InnerExceptions)
    {
        Console.WriteLine($"Error {++counter}: {e.Message}");
    }
}