var task = Task.WhenAll(
    Task.Run(() => throw new Exception("Outer error")),
    Task.Run(() => throw new AggregateException(new InvalidOperationException("Inner Level 1"),
        new ArgumentException("Inner Level 2")
    )));
try
{
    task.Wait();
}
catch (AggregateException ex)
{
    var flattened = ex.Flatten();
    foreach (var innerException in flattened.InnerExceptions)
        Console.WriteLine(innerException.Message);
}