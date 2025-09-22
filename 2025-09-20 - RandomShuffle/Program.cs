var numbers = Enumerable.Range(1, 25).ToArray();

// Sort using random order method

var shuffled = numbers.OrderBy(n => Random.Shared.Next()).ToArray();

foreach (var number in shuffled)
{
    Console.Write($"{number} ");
}

Console.WriteLine();

// Shuffle in place

Random.Shared.Shuffle(numbers);

foreach (var number in numbers)
{
    Console.Write($"{number} ");
}