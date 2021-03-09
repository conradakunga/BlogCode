using System;
using System.Text.Json;

namespace EmptyString
{
    class Program
    {
        static void Main(string[] args)
        {
            var animal = new Animal()
            {
                Name = "Dog",
                Legs = 4
            };
            var serialized = JsonSerializer.Serialize(animal, new JsonSerializerOptions() { WriteIndented = true });
            Console.WriteLine(serialized);

            animal = new Animal()
            {
                Name = null,
                Legs = 4
            };
            serialized = JsonSerializer.Serialize(animal, new JsonSerializerOptions() { WriteIndented = true });
            Console.WriteLine(serialized);

            animal = new Animal()
            {
                Name = null,
                Legs = 4
            };
            serialized = JsonSerializer.Serialize(animal, new JsonSerializerOptions()
            {
                WriteIndented = true,
                IgnoreNullValues = true

            });

            animal = new Animal()
            {
                Name = null,
                Legs = 4
            };

            // create the options
            var options = new JsonSerializerOptions() { WriteIndented = true };
            // register the converter
            options.Converters.Add(new NullToEmptyStringConverter());
            // serialize
            serialized = JsonSerializer.Serialize(animal, options);
            Console.WriteLine(serialized);
        }
    }
}
