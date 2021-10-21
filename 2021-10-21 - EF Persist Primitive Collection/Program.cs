using EFTest;
using Microsoft.EntityFrameworkCore;

using (var ctx = new PersonContext())
{
    // Create a sample person if there aren't any
    if (!ctx.People.Any())
    {
        var person = new Person() { Name = "James" };

        //Add the hobbies to the person
        var hobbies = new[] {
                new Hobby(){ Name = "Fishing"},
                new Hobby(){ Name = "Archery"}
            };

        // Persist the person
        person.Hobbies.AddRange(hobbies);
        ctx.People.AddRange(person);
        ctx.SaveChanges();
    }

    // Load all the people, and their hobbies
    var people = ctx.People.Include(x=> x.Hobbies).ToList();
    foreach (var person in people)
    {
        // Print their name
        Console.WriteLine($"My name is {person.Name}. My hobbies are:");
        // Print their hobbies
        foreach (var hobby in person.Hobbies)
            Console.WriteLine($"\t {hobby.Name}");
    }

    // Create an animal if there aren't any
    if (!ctx.Animals.Any())
    {
        var animal = new Animal() { Name = "Dog" };

        //Add foods to the animal
        var foods = new[] { "Meat", "Fish", "Liver" };
        animal.Foods.AddRange(foods);

        // Persist the changes
        ctx.Animals.AddRange(animal);
        ctx.SaveChanges();
    }

    // List all the animals
    var animals = ctx.Animals.ToList();
    foreach (var animal in animals)
    {
        // Print their name
        Console.WriteLine($"I am a {animal.Name}. I like to eat:");
        // Print the foods they like to eat
        foreach (var food in animal.Foods)
            Console.WriteLine($"\t {food}");
    }
}
