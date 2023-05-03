using Greeter.Logic;

var clock = new SystemClock();
var greeter = new Greeter.Logic.Greeter(clock);
Console.WriteLine($"{greeter.Greet()} world!");
