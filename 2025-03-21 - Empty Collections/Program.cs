using v1;

var agency = new Agency()
{
    Name = "Savak",
    Spies = null
};

var agency2 = new Agency()
{
    Name = "Savak",
    Spies = []
};

var agency3 = new Agency()
{
    Name = "Savak",
    Spies = Array.Empty<Spy>()
};


//
// Later
//

// List all the spies in this agency
foreach (var spy in agency.Spies)
{
    Console.WriteLine($"{spy.FirstName} {spy.Surname}");
}