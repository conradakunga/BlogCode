var man = new Human("James Bond");
var chicken = new Bird("Chicken", 2);
var dog = new Animal("Dog", 2);

Console.WriteLine(Greet(man));
Console.WriteLine(Greet(dog));
Console.WriteLine(Greet(chicken));

return;

string Greet(LivingThing livingThing)
{
    return livingThing switch
    {
        Human human => $"I am {human.Name}, a human",
        Animal animal => $"It seems I am {animal.Name}, a animal",
        Bird bird => $"I am a bird of {bird.Name}"
    };
}

public record class Human(string Name);

public record class Animal(string Name, int Legs);

public record class Bird(string Name, int Wings);

public union LivingThing(Human, Animal, Bird);