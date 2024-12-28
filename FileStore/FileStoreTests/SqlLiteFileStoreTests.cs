using System.Text;
using FileStore.Implementations;
using FluentAssertions;

namespace FileStoreTests;

public class SqlLiteFileStoreTests : IDisposable
{
    private const string UserID = "user";
    private const string ConnectionString = "Data Source=Testing.db";

    [Fact]
    public async Task NonExistent_ID_Check_Returns_False()
    {
        var store = new SqlIteFileStore(ConnectionString, UserID);
        var exists = await store.Exists(Guid.NewGuid());
        exists.Should().BeFalse();
    }

    [Fact]
    public async Task Download_NonExistent_ID_Throws_Exception()
    {
        var store = new SqlIteFileStore(ConnectionString, UserID);
        var ex = await Record.ExceptionAsync(() => store.Download(Guid.NewGuid(), CancellationToken.None));
        ex.Should().BeOfType<FileNotFoundException>();
    }

    [Fact]
    public async Task File_Upload_And_Delete_Is_Successful()
    {
        var store = new SqlIteFileStore(ConnectionString, UserID);
        // Create a new temp file with some known text
        var testFile = Path.GetTempFileName();
        var uploadData = Encoding.Default.GetBytes("This is some test data");
        // Save the temp file
        await File.WriteAllBytesAsync(testFile, uploadData);
        // Upload the file
        var meta = await store.Upload(new FileStream(testFile, FileMode.Open), "File.txt", CancellationToken.None);

        // Assert Exists works
        var exists = await store.Exists(meta.ID);
        exists.Should().BeTrue();

        // Delete
        await store.Delete(meta.ID);

        // Asser Exists no longer works
        exists = await store.Exists(meta.ID);
        exists.Should().BeFalse();
    }

    [Fact]
    public async Task File_Upload_And_Download_Is_Successful()
    {
        const string fileName = "File.txt";
        var store = new SqlIteFileStore(ConnectionString, UserID);
        // Create a new temp file with some known text
        var testFile = Path.GetTempFileName();
        var uploadData = Encoding.Default.GetBytes("This is some test data");
        // Save the temp file
        await File.WriteAllBytesAsync(testFile, uploadData);
        // Upload the file
        var meta = await store.Upload(new FileStream(testFile, FileMode.Open), fileName, CancellationToken.None);

        // Asser valid return
        meta.Should().NotBeNull();
        // Assert the ID is valid
        meta.ID.Should().NotBeEmpty();
        // Assert the name is valid
        meta.FileName.Should().Be(fileName);

        // Assert Exists works
        var exists = await store.Exists(meta.ID);
        exists.Should().BeTrue();

        // Download immediately
        byte[] data;
        using (var ms = new MemoryStream())
        {
            await (await store.Download(meta.ID, CancellationToken.None)).CopyToAsync(ms);
            data = ms.ToArray();
        }

        // Assert data was returned
        data.Should().NotBeEmpty();

        // Assert the data hasn't changed
        data.Should().BeEquivalentTo(uploadData);

        // Cleanup
        await store.Delete(meta.ID);
    }

    public void Dispose()
    {
        File.Delete(ConnectionString);
    }
}