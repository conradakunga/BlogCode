using Dapper;
using Microsoft.Data.Sqlite;

namespace FileStore.Implementations;

public sealed class SqlIteFileStore : IFileStore
{
    private readonly string _connectionString;
    private readonly string _userID;

    public SqlIteFileStore(string connectionString, string userID)

    {
        _connectionString = connectionString;
        _userID = userID;
        //
        // Create table if it doesnt exist
        //

        // Table scripts
        const string tableSql = """
                                create table main.Files
                                (
                                    Id          TEXT not null
                                        constraint pk_Files
                                            primary key,
                                    FileName    text not null,
                                    UserID      TEXT not null,
                                    Data        BLOB not null,
                                    UploadDate TEXT not null
                                );
                                """;

        const string indexSql = """
                                create index main.ix_ID_Name
                                    on main.Files (Id, UserID, FileName);
                                """;
        // Check if table exists
        using (var cn = new SqliteConnection(_connectionString))
        {
            var meta = cn.QuerySingle<int>(
                "SELECT count(1) FROM sqlite_master WHERE type='table' AND name='Files'");
            if (meta == 0)
            {
                cn.Execute(tableSql);
                cn.Execute(indexSql);
            }
        }
    }

    public async Task<FileMetaData> GetMetaData(Guid id, CancellationToken token)
    {
        await using (var cn = new SqliteConnection(_connectionString))
        {
            var meta = await cn.QuerySingleOrDefaultAsync(
                "SELECT Id, FileName, DateCreated from Files Where Id = @id AND UserID = @userID",
                new { id, userID = _userID });
            if (meta == null)
                throw new FileNotFoundException("File not found", id.ToString());
            return meta;
        }
    }

    public async Task<FileMetaData> Upload(Stream fileStream, string fileName, CancellationToken token)
    {
        // Generate ID
        var id = Guid.CreateVersion7();
        token.ThrowIfCancellationRequested();
        byte[] data;
        using (var memoryStream = new MemoryStream())
        {
            await fileStream.CopyToAsync(memoryStream, token);
            data = memoryStream.ToArray();
        }

        var dateCrated = DateTime.UtcNow;
        var param = new DynamicParameters();
        param.Add("Id", id);
        param.Add("FileName", fileName);
        param.Add("UserID", _userID);
        param.Add("Data", data);
        param.Add("DateCreated", dateCrated);

        await using (var cn = new SqliteConnection(_connectionString))
        {
            await cn.ExecuteAsync("INSERT INTO Files VALUES (@Id, @FileName, @UserID,@Data)", param);
        }

        return new FileMetaData(fileName, id, dateCrated);
    }

    public async Task<bool> Exists(Guid id)
    {
        await using (var cn = new SqliteConnection(_connectionString))
        {
            return await cn.QuerySingleAsync<bool>(
                "SELECT EXISTS(SELECT 1 FROM FILES WHERE Id = @Id AND UserID = @UserID)",
                new { Id = id, UserID = _userID });
        }
    }

    public async Task Delete(Guid id)
    {
        await using (var cn = new SqliteConnection(_connectionString))
        {
            await cn.ExecuteAsync("DELETE FROM Files WHERE ID = @Id AND UserID = @UserID",
                new { Id = id, UserID = _userID });
        }
    }

    public async Task<Stream> Download(Guid id, CancellationToken token)
    {
        await using (var cn = new SqliteConnection(_connectionString))
        {
            var data = await cn.QuerySingleOrDefaultAsync<byte[]>(
                "SELECT Data from Files Where Id = @id AND UserID = @userID", new { id, userID = _userID });
            if (data == null)
                throw new FileNotFoundException("File not found", id.ToString());

            return new MemoryStream(data);
        }
    }
}