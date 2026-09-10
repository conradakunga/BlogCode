Animal[] animals =
[
    new Primate("Baboon", 4),
    new Primate("Chimpanzee", 4),
    new Bird("Chicken", 2, 2),
    new Bird("Turkey", 2, 2),
];

foreach (var animal in animals)
{
    Process(animal);
    ProcessNew(animal);
}

return;

void Process(Animal animal)
{
    if (animal is Bird)
    {
        var temp = (Bird)animal;
        Console.WriteLine($"Hello {temp.Name} bird: you have {temp.Legs} legs, {temp.Wings}");
    }
    else if (animal is Primate)
    {
        var temp = (Primate)animal;
        Console.WriteLine($"Hello {temp.Name} Primate: you have {temp.Legs} legs");
    }
}

void ProcessNew(Animal animal)
{
    if (animal is Bird bird)
    {
        Console.WriteLine($"Hello {bird.Name} bird: you have {bird.Legs} legs, {bird.Wings}");
    }
    else if (animal is Primate primate)
    {
        Console.WriteLine($"Hello {primate.Name} Primate: you have {primate.Legs} legs");
    }
}