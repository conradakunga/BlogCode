using System.Text.Json;
using AnimalV1 = V1.Animal;
using AnimalV2 = V2.Animal;
using AnimalV3 = V3.Animal;
using AnimalV4 = V4.Animal;

var options = new JsonSerializerOptions() { WriteIndented = true };

var json = "";

var catv1 = new AnimalV1() { Name = "Cat", Legs = 4, Sound = "Meow" };

json = JsonSerializer.Serialize(catv1, options);

Console.WriteLine(json);

var catv2 = new AnimalV2() { Name = "Cat", Legs = 4, Sound = "Meow" };

json = JsonSerializer.Serialize(catv2, options);

Console.WriteLine(json);

var catv3 = new AnimalV3() { Name = "Cat", Legs = 4, Sound = "Meow", Color = "Brown" };

json = JsonSerializer.Serialize(catv3, options);

Console.WriteLine(json);

var catv4 = new AnimalV4() { Name = "Cat", Legs = 4, Sound = "Meow", Color = "Brown", ID = Guid.NewGuid() };

json = JsonSerializer.Serialize(catv4, options);

Console.WriteLine(json);
