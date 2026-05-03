var numbers = Enumerable.Range(1, 10).ToList();
numbers.ForEach(Console.WriteLine);

var evenNumbers = Enumerable.Range(1, 10).Where(x => x % 2 == 0).ToList();
evenNumbers.ForEach(Console.WriteLine);

var oddNumbers = Enumerable.Range(1, 10).Where(x => x % 2 != 0).ToList();
oddNumbers.ForEach(Console.WriteLine);

var smallNumbers = Enumerable.Range(0, 20).Select(x => x / 20.0).ToList();
smallNumbers.ForEach(Console.WriteLine);