using System.Data;
using Bogus;
using Dapper;
using MySqlConnector;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

const string connectionString = "Server=localhost;userid=root;password=mystrongpassword123;database=testdb";

// Create and configure a Bogus faker
var faker = new Faker<Spy>()
    .RuleFor(f => f.Fullnames, f => f.Person.FullName)
    .RuleFor(f => f.DateOfBirth, f => f.Date.Past(50));

// Insert

await using (var cn = new MySqlConnection(connectionString))
{
    // Generate a new spy
    var spy = faker.Generate();
    // Create the Dapper dynamic parameters
    var param = new DynamicParameters();
    param.Add("fullnames", spy.Fullnames);
    param.Add("dateofbirth", spy.DateOfBirth);

    Log.Information("Creating a spy with name {Fullnames}, Date Of Birth: {DateOfBirth}", spy.Fullnames,
        spy.DateOfBirth);
    // Execute query
    const string query = "INSERT spies (fullnames,dateofbirth) values (@fullnames,@dateofbirth)";
    var result = await cn.ExecuteAsync(query, param);
    Log.Information("{Count} records affected", result);
}

// List

var spies = new List<Spy>();
var spyID = 0;

await using (var cn = new MySqlConnection(connectionString))
{
    spies = (await cn.QueryAsync<Spy>("SELECT spyid, fullnames,dateofbirth FROM spies")).AsList();
    spies.ForEach(spy =>
        Log.Information("ID: {ID}, Fullname: {Fullnames}, DateOfBirth: {DateOfBirth}",
            spy.spyID, spy.Fullnames,
            spy.DateOfBirth));
}

// Get the last spyID
spyID = spies.Last().spyID;

Log.Information("{Count} records returned", spies.Count);


// Update

await using (var cn = new MySqlConnection(connectionString))
{
    // Generate a new spy
    var spy = faker.Generate();
    //Create the Dapper dynamic parameters
    var param = new DynamicParameters();
    param.Add("fullnames", spy.Fullnames);
    param.Add("dateofbirth", spy.DateOfBirth);
    param.Add("spyid", spyID);
    const string query = "UPDATE spies SET fullnames=@fullnames, dateofbirth=@dateofBirth WHERE spyid=@spyid";
    Log.Information("Updating spy fullname and date of birth to {Fullnames} and {DateOfBirth}", spy.Fullnames,
        spy.DateOfBirth);
    // Execute the query
    var result = await cn.ExecuteAsync(query, param);
    Log.Information("{Count} records affected", result);
}

// Delete

await using (var cn = new MySqlConnection(connectionString))
{
    var param = new DynamicParameters();
    param.Add("spyid", spyID);
    const string query = "DELETE from spies WHERE spyid=@spyid";
    Log.Information("Deleting spy with ID {ID}", spyID);
    // Execute query
    var result = await cn.ExecuteAsync(query, param);
    Log.Information("{Count} records affected", result);
}