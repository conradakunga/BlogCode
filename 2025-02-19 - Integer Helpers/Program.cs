var input = 7;

// 
// Odd numbers
//
if (input % 2 == 0)
    Console.WriteLine($"{input} is even");
else
    Console.WriteLine($"{input} is odd");


if (int.IsEvenInteger(input))
    Console.WriteLine($"{input} is even");
else
    Console.WriteLine($"{input} is odd");

//
// Even numbers
//

if (input % 2 != 0)
    Console.WriteLine($"{input} is odd");
else
    Console.WriteLine($"{input} is even");


if (int.IsOddInteger(input))
    Console.WriteLine($"{input} is odd");
else
    Console.WriteLine($"{input} is even");

//
// Positive numbers
//

if (input > 0)
    Console.WriteLine($"{input} is positive");
else
    Console.WriteLine($"{input} is negative");

if (int.IsPositive(input))
    Console.WriteLine($"{input} is positive");
else
    Console.WriteLine($"{input} is negative");

//
// Negative Numbers
//

if (input < 0)
    Console.WriteLine($"{input} is negative");
else
    Console.WriteLine($"{input} is positive");

if (int.IsNegative(input))
    Console.WriteLine($"{input} is negative");
else
    Console.WriteLine($"{input} is positive");

//
// Powers of 2
//

Console.WriteLine(IsPowerOfTwo(8));
Console.WriteLine(int.IsPow2(8));
return;

bool IsPowerOfTwo(int value)
{
    return value > 0 && Math.Log2(value) % 1 == 0;
}