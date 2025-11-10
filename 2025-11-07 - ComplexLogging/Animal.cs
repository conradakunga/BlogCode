public class Animal
{
    public string Name { get; set; }
    public int Legs { get; set; }
    public override string ToString() => $"Animal ({Name})";
}