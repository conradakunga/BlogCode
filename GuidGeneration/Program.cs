// With pause

{
    var list = new List<Guid>();

    for (var i = 0; i < 10; i++)
    {
        var temp = Guid.CreateVersion7();
        Console.WriteLine(temp);
        list.Add(temp);
        Thread.Sleep(1);
    }

    Console.WriteLine();

    list.Sort();

    list.ForEach(x => Console.WriteLine(x));
}
// Without pause
{
    var list = new List<Guid>();
    for (var i = 0; i < 10; i++)
    {
        var temp = Guid.CreateVersion7();
        Console.WriteLine(temp);
        list.Add(temp);
    }

    Console.WriteLine();

    list.Sort();

    list.ForEach(x => Console.WriteLine(x));
}