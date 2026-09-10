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
}

return;

void Process(Animal animal)
{
    switch (animal)
    {
        case Primate primate:
            Console.WriteLine($"Hello {primate.Name} Primate: you have {primate.Legs} legs");
            break;
        case Bird bird:
            Console.WriteLine($"Hello {bird.Name} bird: you have {bird.Legs} legs, {bird.Wings}");
            break;
        default:
            Console.WriteLine("Unknown");
            break;
    }
}