using Serilog;

Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));

Log.Logger = new LoggerConfiguration()
    .WriteTo.Seq("http://localhost:5341")
    .WriteTo.Console()
    .CreateLogger();

string fruit = "Apple";

Log.Information("The fruit is a {Fruit}", fruit);

var animal = new Animal { Name = "Dog", Legs = 4 };
Log.Information("Here is the {@Animal}", animal);
animal = new Animal { Name = "Bird", Legs = 2 };
Log.Information("Here is the {Animal}", animal);

Log.CloseAndFlush();