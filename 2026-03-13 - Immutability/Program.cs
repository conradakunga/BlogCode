using v2;

var subaru = new Car
{
    Id = 1,
    Capacity = 2000,
    Make = "Subaru",
    Model = "Outback",
    YearOfManufacture = 2026
};

var dto = new CarDTO
{
    Id = subaru.Id,
    Capacity = subaru.Capacity,
    Make = subaru.Make,
    Model = subaru.Model,
    YearOfManufacture = subaru.YearOfManufacture
};


dto.Make = "Mercedes";
dto.Model = "G-Wagen";

Console.WriteLine(dto);