int[] left = [1, 2, 3, 4, 5, 6, 7];
int[] right = [5, 6, 7, 8, 9, 10];

// Return items only in the left collection
var leftOnly = left.Except(right).ToList();
// Write to console
leftOnly.ForEach(x => Console.Write($"{x} "));
Console.WriteLine();

// Return items only in the right collection
var rightOnly = right.Except(left).ToList();
// Write to console
rightOnly.ForEach(x => Console.Write($"{x} "));
Console.WriteLine();

// Returns items present in both collections
var both = left.Intersect(right).ToList().ToList();
// Write to console
both.ForEach(x => Console.Write($"{x} "));
Console.WriteLine();

// Returns items from both collections
var combined = left.Union(right).ToList();
// Write to console
combined.ForEach(x => Console.Write($"{x} "));
Console.WriteLine();

// Returns items only in left or only in right
var unique = left.Except(right).Union(right.Except(left)).ToList();
// Write to console
unique.ForEach(x => Console.Write($"{x} "));
Console.WriteLine();