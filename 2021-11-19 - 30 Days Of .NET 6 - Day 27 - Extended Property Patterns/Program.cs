
using System;
using System.Linq;

var animals = new Animal[]{
    new Mammal(){ Name = "Dog", Movement = new Movement() { Legs = 4, Speed = Speed.Medium }},
    new Mammal(){ Name = "Cat", Movement = new Movement() { Legs = 4, Speed = Speed.Slow }},
    new Mammal(){ Name = "Dolphin", Movement = new Movement() { Fins = 2, Speed=Speed.Fast }},
    new Mammal(){ Name = "Whale", Movement = new Movement() { Fins = 2, Speed=Speed.Slow }},
    new Bird(){ Name = "Chicken", Movement = new Movement() { Legs = 2, Speed = Speed.Slow }},
    new Bird(){ Name = "Duck", Movement = new Movement() { Legs = 2,Speed = Speed.Slow }}
};

var result = animals.Where(a => a is Mammal && a.Movement.Legs == 0 && a.Movement.Speed == Speed.Slow);
foreach (var animal in result)
    Console.WriteLine($"I am a {animal.Name} and I have no legs!");

foreach (var animal in animals)
{
    if (animal is Mammal { Movement: { Legs: 0, Speed: Speed.Slow } })
        Console.WriteLine($"I am a {animal.Name} and I have no legs!");
}

foreach (var animal in animals)
{
    if (animal is Mammal { Movement.Legs: 0, Movement.Speed: Speed.Slow })
        Console.WriteLine($"I am a {animal.Name} and I have no legs!");
}

public enum Speed { VeryFast, Fast, Medium, Slow }
public record Movement
{
    public byte Legs { get; init; }
    public byte Fins { get; init; }
    public Speed Speed { get; init; }
}
public record Animal
{
    public string Name { get; init; }
    public Movement Movement { get; init; }
}
public record Mammal : Animal { }
public record Bird : Animal { }


