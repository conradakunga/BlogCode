// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public sealed class Car
{
    private readonly string _name;
    private readonly string _make;
    private readonly string _model;

    public Car(string name, string make, string model)
    {
        _name = name;
        _make = make;
        _model = model;
    }

    public void Prepare()
    {
        _make = "Generic";
    }
}