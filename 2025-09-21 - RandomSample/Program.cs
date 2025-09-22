var numbers = Enumerable.Range(1, 25).ToArray();

var shuffled = numbers.OrderBy(n => Random.Shared.Next()).Take(10).ToArray();

foreach (var number in shuffled)
{
    Console.Write($"{number} ");
}

Console.WriteLine();

var sampled = Random.Shared.GetItems(numbers, 10);

foreach (var number in sampled)
{
    Console.Write($"{number} ");
}

