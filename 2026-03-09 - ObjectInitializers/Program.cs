var request = new V1.CarCreateRequest("Subaru", "Outback", 2025,
    "Africa", false, 2000);

var newRequest = new V2.CarCreateRequest
{
    Make = "Subaru",
    Model = "Outback",
    Year = 2025,
    Market = "Africa",
    LeftHandDrive = false,
    EngineCapacity = 2000
};