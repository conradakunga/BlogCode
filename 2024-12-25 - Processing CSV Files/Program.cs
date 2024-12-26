using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

// var data = File.ReadAllText("data.csv");
// // Create  collection - a list of spies
// List<Spy> spies = new();
// // Split the data into an array of rows, using the newline
// var rows = data.Split(Environment.NewLine);
// // Skip the first row, as it is a header
// foreach (var line in rows.Skip(1))
// {
//     // Split each row into an array of columns by comma
//     var columns = line.Split(",");
//     // Using the columns, create a spy
//     spies.Add(new Spy(columns[0], Convert.ToInt32(columns[1]), columns[2]));
// }

{
    // Create a reader
    using var reader = new StreamReader("Data.csv");
    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
    // Create an IEnumerable of Spy
    var allSpies = csv.GetRecords<Spy>();
    // Actually read the spy from file and process
    foreach (var spy in allSpies)
    {
        Console.WriteLine($"Name {spy.Name}, Age {spy.Age}, Service {spy.Service}");
    }
}

{
    // Create a reader
    using var reader = new StreamReader("Data2.csv");
    // Create a csv reader
    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
    // Register our classmap
    csv.Context.RegisterClassMap<SpyMap>();
    // Create an IEnumerable of Spy
    var allSpies = csv.GetRecords<Spy>();
    // Actually read the spy from file and process
    foreach (var spy in allSpies)
    {
        Console.WriteLine($"Name {spy.Name}, Age {spy.Age}, Service {spy.Service}");
    }
}
{
    // Create a configuration
    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = false
    };
    // Create a reader
    using var reader = new StreamReader("Data3.csv");
    // Create a csv reader, passing the configuration
    using var csv = new CsvReader(reader, config);
    // Regiser our classmap
    csv.Context.RegisterClassMap<SpyMap>();
    // Create an IEnumerable of Spy
    var allSpies = csv.GetRecords<Spy>();
    // Actually read the spy from file and process
    foreach (var spy in allSpies)
    {
        Console.WriteLine($"Name {spy.Name}, Age {spy.Age}, Service {spy.Service}");
    }
}
{
    List<Spy> spies =
    [
        new Spy { Name = "James Bond", Age = 50, Service = "MI-6" },
        new Spy { Name = "Vesper Lynd", Age = 35, Service = "MI-6" }
    ];
    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = false
    };
    using var writer = new StreamWriter("OutputNoHeader.csv");
    using var csv = new CsvWriter(writer, config);
    csv.WriteRecords(spies);
}
{
    List<Spy> spies =
    [
        new Spy { Name = "James Bond", Age = 50, Service = "MI-6" },
        new Spy { Name = "Vesper Lynd", Age = 35, Service = "MI-6" }
    ];
    using var writer = new StreamWriter("OutputNamedHeader.csv");
    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    csv.Context.RegisterClassMap<SpyMap>();
    csv.WriteRecords(spies);
}