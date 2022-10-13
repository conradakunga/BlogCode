// Create a new Random with a seed
var rnd = new Random(500);

// Generate a list of numbers sorted randomly
var numbers = Enumerable.Range(1, 15).OrderBy(element => rnd.Next()).ToList();

// Print the numbers
PrintNumbers(numbers);

// Order the numbers with the old (and still supported) syntax
var ordered = numbers.OrderBy(number => number).ToList();

PrintNumbers(ordered);
// Order the numbers with the new syntax
var ordered2 = numbers.Order().ToList();

PrintNumbers(ordered2);

//Order the numbers in reverse with the new syntax
var reversed = numbers.OrderDescending().ToList();

PrintNumbers(reversed);


// Function to print numbers to console 
void PrintNumbers(List<int> collection)
{
    collection.ForEach(number => Console.WriteLine(number));
    Console.WriteLine();
}