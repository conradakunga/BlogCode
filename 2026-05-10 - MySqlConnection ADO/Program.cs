using System.Data;
using Bogus;
using MySqlConnector;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

const string connectionString = "Server=localhost;userid=root;password=mystrongpassword123;database=testdb";

// Create and configure a Bogus faker

var faker = new Faker<Spy>()
    .RuleFor(f => f.Fullnames, f => f.Person.FullName)
    .RuleFor(f => f.DateOfBirth, f => DateOnly.FromDateTime(f.Date.Past(50)));

// Insert

// await using (var cn = new MySqlConnection(connectionString))
// {
//     // Open the connection
//     await cn.OpenAsync();
//     // Create a command object
//     await using (var cmd = cn.CreateCommand())
//     {
//         var spy = faker.Generate();
//         // Set the command tet
//         cmd.CommandText = "INSERT spies(fullnames,dateofbirth) values (@fullnames,@dateofbirth)";
//         //
//         // Populate the parameters
//         //
//         var pFullnames = new MySqlParameter("@fullnames", MySqlDbType.VarChar, 100)
//         {
//             Value = spy.Fullnames
//         };
//         var pDateOfBirth = new MySqlParameter("@dateofbirth", MySqlDbType.Date, 16)
//         {
//             Value = spy.DateOfBirth
//         };
//         // Add parameters to command
//         cmd.Parameters.Add(pFullnames);
//         cmd.Parameters.Add(pDateOfBirth);
//         Log.Information("Creating a spy with name {Fullnames}, Date Of Birth: {DateOfBirth}", spy.Fullnames,
//             spy.DateOfBirth);
//         // Execute query
//         var result = await cmd.ExecuteNonQueryAsync();
//         Log.Information("{Count} records affected", result);
//     }
//
//     await cn.CloseAsync();
// }

// List

// Store the last SpyID, as that is the row we will edit
int spyID = 0;

await using (var cn = new MySqlConnection(connectionString))
{
    // Open the connection
    await cn.OpenAsync();
    // Create a command object
    await using (var cmd = cn.CreateCommand())
    {
        int counter = 0;
        // Set the command tet
        cmd.CommandText = "SELECT spyid, fullnames,dateofbirth FROM spies";
        // Execute query
        var reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            // Get ordinal allows us to use the name to get the ordinal position
            spyID = reader.GetInt32(reader.GetOrdinal("spyid"));
            var fullnames = reader.GetString(reader.GetOrdinal("fullnames"));
            var dateofbirth = reader.GetDateOnly(reader.GetOrdinal("dateofbirth"));
            Log.Information("ID: {ID}, Fullname: {Fullnames}, DateOfBirth: {DateOfBirth}", spyID, fullnames,
                dateofbirth);
            counter++;
        }

        await reader.CloseAsync();

        Log.Information("{Count} records returned", counter);
    }
}

// Update

// await using (var cn = new MySqlConnection(connectionString))
// {
//     // Open the connection
//     await cn.OpenAsync();
//     // Create a command object
//     await using (var cmd = cn.CreateCommand())
//     {
//         var spy = faker.Generate();
//         // Set the command tet
//         cmd.CommandText = "UPDATE spies SET fullnames=@fullnames, dateofbirth=@dateofBirth WHERE spyid=@spyid";
//         //
//         // Populate the parameters
//         //
//         var pFullnames = new MySqlParameter("@fullnames", MySqlDbType.VarChar, 100)
//         {
//             Value = spy.Fullnames
//         };
//         var pDateOfBirth = new MySqlParameter("@dateofbirth", MySqlDbType.Date, 16)
//         {
//             Value = spy.DateOfBirth
//         };
//         var pSpyID = new MySqlParameter("@spyid", MySqlDbType.Int16, 16)
//         {
//             Value = spyID
//         };
//         // Add parameters to command
//         cmd.Parameters.Add(pFullnames);
//         cmd.Parameters.Add(pDateOfBirth);
//         cmd.Parameters.Add(pSpyID);
//         Log.Information("Updating spy fullname and date of birth to {Fullnames} and {DateOfBirth}", spy.Fullnames,
//             spy.DateOfBirth);
//         // Execute query
//         var result = await cmd.ExecuteNonQueryAsync();
//         Log.Information("{Count} records affected", result);
//     }
//
//     await cn.CloseAsync();
// }

// Delete

await using (var cn = new MySqlConnection(connectionString))
{
    // Open the connection
    await cn.OpenAsync();
    // Create a command object
    await using (var cmd = cn.CreateCommand())
    {
        var spy = faker.Generate();
        // Set the command tet
        cmd.CommandText = "DELETE from spies WHERE spyid=@spyid";
        //
        // Populate the parameter
        //
        var pSpyID = new MySqlParameter("@spyid", MySqlDbType.Int16, 16)
        {
            Value = spyID
        };
        // Add parameters to command
        cmd.Parameters.Add(pSpyID);
        Log.Information("Deleting spy with ID {ID}", spyID);
        // Execute query
        var result = await cmd.ExecuteNonQueryAsync();
        Log.Information("{Count} records affected", result);
    }

    await cn.CloseAsync();
}