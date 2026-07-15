// Create our strucutre

using System.Collections;

var arr = new BitArray(10_000)
{
    // Set some of the bits
    [1000] = true,
    [100] = true
};

// Check if any seat is occuped
Console.WriteLine($"Is at least one seat occupied? {arr.HasAnySet()}");

int count = 0;
foreach (bool element in arr)
{
    if (element)
        count++;
}

Console.WriteLine($"There are {count} seats occupied");

Console.WriteLine($"There are {arr.PopCount()} seats occupied");