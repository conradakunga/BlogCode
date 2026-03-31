using System.Diagnostics;
using Serilog;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

var james = new Person()
{
    FirstName = "James",
    LastName = "Bond",
    Gender = Genders.Male,
};

var unknown = new Person()
{
    FirstName = "Jane",
    LastName = "Bond",
    Gender = Genders.Unknown,
};

var other = new Person()
{
    FirstName = "Great",
    LastName = "Scott",
    Gender = null,
};

var bourne = new Person()
{
    FirstName = "Jason",
    LastName = "Bourne",
    Gender = Genders.Male,
    DateOfBirth = null
};

Log.Information("Welcome {FirstName} {LastName}", james.FirstName, james.LastName);
Log.Information("Welcome {FirstName} {LastName}", other.FirstName, other.LastName);
Log.Information("Welcome {FirstName} {LastName}", unknown.FirstName, unknown.LastName);
Log.Information("Welcome {FirstName} {LastName}", bourne.FirstName, bourne.LastName);