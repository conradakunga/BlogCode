using Serilog;

try
{
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Seq("http://localhost:5341")
        .CreateLogger();

    string fruit = "Apple";

    Log.Information("The fruit is a {Fruit}", fruit);

    var animal = new Animal { Name = "Dog", Legs = 4 };
    Log.Information("Here is the {@Animal}", animal);
    animal = new Animal { Name = "Bird", Legs = 2 };
    Log.Information("Here is the {Animal}", animal);
}
catch (Exception ex)
{
    Log.Error(ex, "An error occurred");
}
finally
{
    Log.CloseAndFlush();
}