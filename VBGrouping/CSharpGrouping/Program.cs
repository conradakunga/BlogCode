var livingThings = new List<LivingThing>();
livingThings.AddRange(new[] {
        new LivingThing()  {Kingdom = "Animal", Name = "Dog", Legs = 4},
            new LivingThing()  {Kingdom = "Animal", Name = "Cat", Legs = 4},
            new LivingThing()  {Kingdom = "Animal", Name = "Horse", Legs = 4},
            new LivingThing()  {Kingdom = "Animal", Name = "Millipede", Legs = 3_000},
            new LivingThing()  {Kingdom = "Animal", Name = "Centipede", Legs = 3_000},
            new LivingThing()  {Kingdom = "Animal", Name = "Octopus", Legs = 8},
            new LivingThing()  {Kingdom = "Animal", Name = "Squid", Legs = 8},
            new LivingThing()  {Kingdom = "Plant", Name = "Rose", Legs = 0},
            new LivingThing()  {Kingdom = "Plant", Name = "Cabbage", Legs = 0},
            new LivingThing()  {Kingdom = "Plant", Name = "Kale", Legs = 0}
    });

// Get the distinct Kingdoms and legs

var distinctElements = livingThings.DistinctBy(t => new { t.Kingdom, t.Legs });
foreach (var element in distinctElements)
{
    Console.WriteLine($"Kingdom: {element.Kingdom}; Legs: {element.Legs}");
}


public class LivingThing
{
    public string Kingdom { get; set; } = default!;
    public string Name { get; set; } = default!;
    public Int16 Legs { get; set; }
}