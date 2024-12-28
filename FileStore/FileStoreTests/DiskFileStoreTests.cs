using System.Text;
using FileStore;
using FluentAssertions;

namespace FileStoreTests;

public class DiskFileStoreTests
{
    [Fact]
    public async Task NonExistent_ID_Check_Returns_False()
    {
        const string userID = "user";
        var store = new DiskFileStore(Path.GetTempPath());
        var exists = await store.Exists(Guid.NewGuid(), userID);
        exists.Should().BeFalse();
    }

    [Fact]
    public async Task Download_NonExistent_ID_Throws_Exception()
    {
        const string userID = "user";
        var store = new DiskFileStore(Path.GetTempPath());
        var ex = await Record.ExceptionAsync(() => store.Download(Guid.NewGuid(), userID, CancellationToken.None));
        ex.Should().BeOfType<FileNotFoundException>();
    }

    [Fact]
    public async Task File_Upload_And_Download_Is_Successful()
    {
        const string userID = "user";
        var store = new DiskFileStore(Path.GetTempPath());
        // Create a new temp file with some known text
        var testFile = Path.GetTempFileName();
        var uploadData = Encoding.Default.GetBytes("This is some test data");
        // Save the temp file
        await File.WriteAllBytesAsync(testFile, uploadData);
        // Upload the file
        var id = await store.Upload(new FileStream(testFile, FileMode.Open), userID, CancellationToken.None);

        // Assert the ID is valid
        id.Should().NotBeEmpty();


        // Assert Exists works
        var exists = await store.Exists(id, userID);
        exists.Should().BeTrue();

        // Download immediately
        byte[] data;
        using (var ms = new MemoryStream())
        {
            await (await store.Download(id, userID, CancellationToken.None)).CopyToAsync(ms);
            data = ms.ToArray();
        }

        // Assert data was returned
        data.Should().NotBeEmpty();

        // Assert the data hasn't changed
        data.Should().BeEquivalentTo(uploadData);
    }
}