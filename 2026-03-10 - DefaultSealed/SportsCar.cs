public class SportsCar : Car
{
    public required int MaxSpeed { get; set; }

    public override string ToString()
    {
        return $"This a Sports {Name}, {Model}";
    }
}