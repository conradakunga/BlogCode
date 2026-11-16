using System.Buffers.Text;
using System.Text.Json;

var req = new SearchRequest
{
    SearchText = "conrad ",
    SortColumn = "Name",
    PageNumber = 0,
    PageSize = 50,
    Database = "Animals",
    ActiveOnly = true
};

// Get the data in bytes
var byteData = JsonSerializer.SerializeToUtf8Bytes(req);
// Convert to a URL representable string
Console.WriteLine(Convert.ToBase64String(byteData) == Base64Url.EncodeToString(byteData));