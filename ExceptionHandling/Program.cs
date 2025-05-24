// {
//     var numerator = 10;
//     var denominator = 0;
//     var result = numerator / denominator;
// }

{
    try
    {
        var numerator = 10;
        var denominator = 0;
        var result = numerator / denominator;
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("You attempted to divide by zero. Please try again.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Some other exception occured: {ex.Message}");
    }
}

{
    var result = Add(1, 3);

    try
    {
        // Call the recursive method
        Recursive();
    }
    catch (StackOverflowException)
    {
        Console.WriteLine("Stack overflow");
    }
    catch (Exception)
    {
        Console.WriteLine("Unexpected exception");
    }

// A recursive method that calls itself
    void Recursive()
    {
        Recursive();
    }

    int Add(int first, int second)
    {
        return first + second;
    }
}