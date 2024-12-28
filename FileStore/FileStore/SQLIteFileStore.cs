using Dapper;
using Microsoft.Data.Sqlite;

namespace FileStore;

public sealed class SqlIteFileStore : IFileStore
{
    private readonly string _connectionString;
    private readonly string _userID;

    public SqlIteFileStore(string connectionString, string userID)
    {
        _connectionString = connectionString;
        _userID = userID;
        // Create table if it doesnt exist
        const string sql = """
                           create table main.Files
                           (
                               Id       TEXT not null
                                   constraint Files_pk
                                       primary key,
                               FileName text not null,
                               UserID   TEXT not null,
                               Data     BLOB not null
                           );
                           """;
        // Check if table exists
        using (var cn = new SqliteConnection(_connectionString))
        {
            var meta = cn.QuerySingle<int>(
                "SELECT count(1) FROM sqlite_master WHERE type='table' AND name='Files'");
            if (meta == 0)
            {
                cn.Execute(sql);
            }
        }
    }

    public async Task<FileMetaData> GetMetaData(Guid id, CancellationToken token)
    {
        await using (var cn = new SqliteConnection(_connectionString))
        {
            var meta = cn.QuerySingleOrDefault<FileMetaData>(
                "SELECT Id, FileName from Files Where Id = @id AND UserID = @userID", new { id, userID = _userID });
            if (meta == null)
                throw new FileNotFoundException("File not found", id.ToString());
            return meta;
        }
    }

    public async Task<FileMetaData> Upload(Stream fileStream, string fileName, CancellationToken token)
    {
        var id = Guid.CreateVersion7();

        token.ThrowIfCancellationRequested();

        byte[] data;
        using (var memoryStream = new MemoryStream())
        {
            await fileStream.CopyToAsync(memoryStream, token);
            data = memoryStream.ToArray();
        }

        var param = new DynamicParameters();
        param.Add("Id", id);
        param.Add("FileName", fileName);
        param.Add("UserID", _userID);
        param.Add("Data", data);

        await using (var cn = new SqliteConnection(_connectionString))
        {
            await cn.ExecuteAsync("INSERT INTO Files VALUES (@Id, @FileName, @UserID,@Data)", param);
        }

        return new FileMetaData(fileName, id);
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
            var data = cn.QuerySingleOrDefault<byte[]>(
                "SELECT Data from Files Where Id = @id AND UserID = @userID", new { id, userID = _userID });
            if (data == null)
                throw new FileNotFoundException("File not found", id.ToString());

            return new MemoryStream(data);
        }
    }
}