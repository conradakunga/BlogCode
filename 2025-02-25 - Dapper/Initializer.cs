using Dapper;
using Microsoft.Data.Sqlite;

public class Initializer
{
    public const string ConnectionString = "data source=test.db";

    public static void EnsureDatabaseExists()
    {
        const string initializeDatabase = """
                                          CREATE TABLE IF NOT EXISTS USERS(UserID INTEGER PRIMARY KEY, Username VARCHAR(100), Password VARCHAR(100));

                                          INSERT INTO USERS (UserID, Username,Password) VALUES (1, 'jbond','jimmybond12$');
                                          """;

        const string checkForTable = "SELECT COUNT(1) FROM sqlite_master WHERE type='table' AND name='USERS'";
        // Create a connection object
        using (var cn = new SqliteConnection(ConnectionString))
        {
            //
            // Check if table exists
            //

            // Set the command text to our query defined above,
            // execute and capture the returned result
            var returns = cn.QuerySingle<int>(checkForTable);
            if (returns == 0)
            {
                // Table does not exist. Initialize
                // Set the command text to the query defined above
                // to generate the database and excute
                cn.Execute(initializeDatabase);
            }
        }
    }
}