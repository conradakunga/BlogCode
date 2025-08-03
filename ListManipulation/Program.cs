List<int> list = [0, 1, 2, 3, 4, 5];

// // Print elements
// list.ForEach(Console.Write);
// Console.WriteLine();
// // Sort the list
// list.Reverse();
// // Print elements
// list.ForEach(Console.Write);
// Console.WriteLine();
//

list = [0, 1, 2, 3, 4, 5];
// Print elements
list.ForEach(Console.Write);
Console.WriteLine();
// Sort the list
list.OrderByDescending(x => x).ToList().ForEach(Console.Write);
Console.WriteLine();
// Print elements
list.ForEach(Console.Write);
Console.WriteLine();