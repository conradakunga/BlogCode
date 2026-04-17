using v3;

var subaru = new Car
{
    Id = 1,
    Capacity = 2000,
    Make = "Subaru",
    Model = "Outback",
    YearOfManufacture = 2026
};

// Loaded initially
var firstDTO = new CarDTO
{
    Id = subaru.Id,
    Capacity = subaru.Capacity,
    Make = subaru.Make,
    Model = subaru.Model,
    YearOfManufacture = subaru.YearOfManufacture
};

// Loaded separately
var secondDTO = new CarDTO
{
    Id = subaru.Id,
    Capacity = subaru.Capacity,
    Make = subaru.Make,
    Model = subaru.Model,
    YearOfManufacture = subaru.YearOfManufacture
};


// Check if the cars are the same

if (firstDTO == secondDTO)
{
    Console.WriteLine("This is the same vehicle");
}
else
{
    Console.WriteLine("These are different vehicles");
}