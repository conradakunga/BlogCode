using System.Buffers.Text;
using System.Text.Json;
using Base64UrlEncode;

var req = new SearchRequest
{
    SearchText = "conrad",
    SortColumn = "Name",
    PageNumber = 0,
    PageSize = 50,
    Database = "Animals",
    ActiveOnly = true
};

// Get the data in bytes
var byteData = JsonSerializer.SerializeToUtf8Bytes(req);
// Convert to a URL representable string
var encodedByteData = Base64Url.EncodeToString(byteData);
Console.WriteLine(encodedByteData);