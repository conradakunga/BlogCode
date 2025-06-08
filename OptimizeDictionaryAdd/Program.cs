// Define dictionary

{
    var numbers = new Dictionary<int, string>();
    // Add items
    numbers.Add(1, "One");
    numbers.Add(2, "Two");
    numbers.Add(3, "Three");
    numbers.Add(4, "Four");
    numbers.Add(5, "Five");

    // Add an item with an existing key
    // numbers.Add(5, "Six");
    if (!numbers.ContainsKey(5))
        numbers.Add(5, "Six");

    // Print items
    foreach (var element in numbers)
    {
        Console.WriteLine($"Key: {element.Key} ; Value: {element.Value}");
    }
}

{
    var numbers = new Dictionary<int, string>();
    //Add items
    numbers[1] = "One";
    numbers[2] = "Two";
    numbers[3] = "Three";
    numbers[4] = "Four";
    numbers[5] = "Five";
    // Update existing key
    numbers[5] = "Six";
    // Print items
    foreach (var element in numbers)
    {
        Console.WriteLine($"Key: {element.Key} ; Value: {element.Value}");
    }
}
{
    var numbers = new Dictionary<int, string>();
    // Add items
    numbers.Add(1, "One");
    numbers.Add(2, "Two");
    numbers.Add(3, "Three");
    numbers.Add(4, "Four");
    numbers.Add(5, "Five");

    if (!numbers.TryAdd(5, "Six"))
        Console.WriteLine("Could not add item with index 5 as it already exists!");

    // Print items
    foreach (var element in numbers)
    {
        Console.WriteLine($"Key: {element.Key} ; Value: {element.Value}");
    }
}