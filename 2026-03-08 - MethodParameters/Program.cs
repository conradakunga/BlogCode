// See https://aka.ms/new-console-template for more information

var factory = new CarFactory();
factory.CreateCar("Subaru", "Outback", 2025, "Africa", false, 2000);

var request = new CarCreateRequest("Subaru", "Outback", 2025, "Africa", false, 2000);
factory.CreateCar(request);

public sealed record CarCreateRequest(
    string make,
    string model,
    int year,
    string market,
    bool leftHandDrive,
    int engineCapacity);