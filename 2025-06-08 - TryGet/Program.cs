// Define dictionary

{
    var numbers = new Dictionary<int, string>
    {
        // Add items
        { 1, "One" },
        { 2, "Two" },
        { 3, "Three" },
        { 4, "Four" },
        { 5, "Five" }
    };

    var itemValue = numbers[5];

    Console.WriteLine(itemValue);

    // itemValue = numbers[6];

    if (numbers.ContainsKey(6))
    {
        itemValue = numbers[6];
        Console.WriteLine(itemValue);
    }
    else
        Console.WriteLine("Key 6 does not exist");
    
    
    if (numbers.TryGetValue(6, out var number))
    {
        itemValue = number;
        Console.WriteLine(itemValue);
    }
    else
        Console.WriteLine("Key 6 does not exist");
}