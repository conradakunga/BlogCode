// Console.WriteLine("Enter first number:");
// var firstInput = Console.ReadLine();
// Console.WriteLine("Enter second number:");
// var secondInput = Console.ReadLine();
//
// int first, second;
// try
// {
//     first = int.Parse(firstInput);
// }
// catch (Exception e)
// {
//     Console.WriteLine("Invalid first number");
//     return;
// }
//
// try
// {
//     second = int.Parse(secondInput);
// }
// catch (Exception e)
// {
//     Console.WriteLine("Invalid second number");
//     return; 
// }
//
// Console.WriteLine($"The result is: {first + second}");

int first, second;
Console.WriteLine("Enter first number:");
while (!int.TryParse(Console.ReadLine(), out first)) ;
Console.WriteLine("Enter second number:");
while (!int.TryParse(Console.ReadLine(), out second)) ;

Console.WriteLine($"The result is: {first + second}");