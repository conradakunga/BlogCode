using System.Text;
using FileStore;
using FluentAssertions;

namespace FileStoreTests;

public class DiskFileStoreTests
{
    private const string UserID = "user";

    [Fact]
    public async Task NonExistent_ID_Check_Returns_False()
    {
        const string userID = "user";
        var store = new DiskFileStore(Path.GetTempPath(), userID);
        var exists = await store.Exists(Guid.NewGuid());
        exists.Should().BeFalse();
    }

    [Fact]
    public async Task Download_NonExistent_ID_Throws_Exception()
    {
        var store = new DiskFileStore(Path.GetTempPath(), UserID);
        var ex = await Record.ExceptionAsync(() => store.Download(Guid.NewGuid(), CancellationToken.None));
        ex.Should().BeOfType<FileNotFoundException>();
    }

    [Fact]
    public async Task File_Upload_And_Download_Is_Successful()
    {
        var store = new DiskFileStore(Path.GetTempPath(), "user");
        // Create a new temp file with some known text
        var testFile = Path.GetTempFileName();
        var uploadData = Encoding.Default.GetBytes("This is some test data");
        // Save the temp file
        await File.WriteAllBytesAsync(testFile, uploadData);
        // Upload the file
        var id = await store.Upload(new FileStream(testFile, FileMode.Open), CancellationToken.None);

        // Assert the ID is valid
        id.Should().NotBeEmpty();


        // Assert Exists works
        var exists = await store.Exists(id);
        exists.Should().BeTrue();

        // Download immediately
        byte[] data;
        using (var ms = new MemoryStream())
        {
            await (await store.Download(id, CancellationToken.None)).CopyToAsync(ms);
            data = ms.ToArray();
        }

        // Assert data was returned
        data.Should().NotBeEmpty();

        // Assert the data hasn't changed
        data.Should().BeEquivalentTo(uploadData);
    }
}