using System.Data;
using MySqlConnector;

const string connectionString = "Server=localhost;userid=root;password=mystrongpassword123;database=testdb";

// Sync version

using (var cn = new MySqlConnection(connectionString))
{
    // Open the connection
    cn.Open();
    // Create a command object
    using (var cmd = cn.CreateCommand())
    {
        // Query the current date and time
        cmd.CommandText = "Select CURRENT_TIMESTAMP";
        // Get the result from command execution
        DateTime result = (DateTime)cmd.ExecuteScalar()!;
        // Write to console
        Console.WriteLine(result);
    }

    cn.Close();
}


// Async version

await using (var cn = new MySqlConnection(connectionString))
{
    // Open the connection
    await cn.OpenAsync();
    // Create a command object
    await using (var cmd = cn.CreateCommand())
    {
        // Query the current date and time
        cmd.CommandText = "Select CURRENT_TIMESTAMP";
        // Get the result from command execution
        DateTime result = (DateTime)(await cmd.ExecuteScalarAsync())!;
        // Write to console
        Console.WriteLine(result);
    }

    await cn.CloseAsync();
}

// Sync version

using (var cn = new MySqlConnection(connectionString))
{
    // Open the connection
    cn.Open();
    // Create a command object
    using (var cmd = cn.CreateCommand())
    {
        // Query the current date and time
        cmd.CommandText = "Select CURRENT_TIMESTAMP";
        // Get a reader, specifying to close the connection when done
        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        {
            // Fetch the date and time
            while (reader.Read())
            {
                // Write to console
                Console.WriteLine(reader.GetDateTime(0));
            }

            // Close the read
            reader.Close();
        }
    }
}


// Async version

using (var cn = new MySqlConnection(connectionString))
{
    // Open the connection
    await cn.OpenAsync();
    // Create a command object
    using (var cmd = cn.CreateCommand())
    {
        // Query the current date and time
        cmd.CommandText = "Select CURRENT_TIMESTAMP";
        // Get a reader, specifying to close the connection when done
        await using (var reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection))
        {
            // Fetch the date and time
            while (await reader.ReadAsync())
            {
                // Write to console
                Console.WriteLine(reader.GetDateTime(0));
            }

            // Close the read
            await reader.CloseAsync();
        }
    }
}