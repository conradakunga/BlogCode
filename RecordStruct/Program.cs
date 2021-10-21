using AnimalClass = Animal.Class.Animal;
using AnimalStruct = Animal.Struct.Animal;
using AnimalRecordStruct = Animal.RecordStruct.Animal;
using AnimalRecord = Animal.Record.Animal;
using ReadOnlyAnimalRecordStruct = Animal.ReadOnlyRecordStruct.Animal;

var firstClass = new AnimalClass() { Name = "Dog", Legs = 4 };
var secondClass = firstClass;

Console.WriteLine($"First class name is {firstClass.Name} and legs is {firstClass.Legs}");
Console.WriteLine($"Second class name is {secondClass.Name} and legs is {secondClass.Legs}");

firstClass.Name = "Cat";

Console.WriteLine($"First class name is {firstClass.Name} and legs is {firstClass.Legs}");
Console.WriteLine($"Second class name is {secondClass.Name} and legs is {secondClass.Legs}");

var firstStruct = new AnimalStruct() { Name = "Dog", Legs = 4 };
var secondStruct = firstStruct;

Console.WriteLine($"First struct name is {firstStruct.Name} and legs is {firstStruct.Legs}");
Console.WriteLine($"Second struct name is {secondStruct.Name} and legs is {secondStruct.Legs}");

firstStruct.Name = "Cat";

Console.WriteLine($"First struct name is {firstStruct.Name} and legs is {firstStruct.Legs}");
Console.WriteLine($"Second struct name is {secondStruct.Name} and legs is {secondStruct.Legs}");

var animalTuple = Tuple.Create("Dog", 4);

var animalTuple2 = new Tuple<string, int>("Dog", 4);

Console.WriteLine($"Animal Tuple name is {animalTuple.Item1} and legs is {animalTuple.Item2}");

var animalValueTuple = (Name: "Dog", Legs: 4);

Console.WriteLine($"Animal Value Tuple name is {animalValueTuple.Name} and legs is {animalValueTuple.Legs}");

var converted = animalValueTuple.ToTuple();

Console.WriteLine($"Converted Animal Value Tuple name is {converted.Item1} and legs is {converted.Item2}");

var convertedValueTuple = animalTuple.ToValueTuple();

var mouse = new AnimalRecordStruct("Mouse", 4);

mouse.Name = "Mongoose";

var rat = new AnimalRecord("Rat", 4);

// rat.Name = "Mongoose"; // Won't compile

var rabbit = new ReadOnlyAnimalRecordStruct("Rabbit", 4);

//rabbit.Name = "Mongoose"; // Won't compile