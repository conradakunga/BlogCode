using System.Buffers.Text;
using System.Text;

const string encodedData =
    "eyJTZWFyY2hUZXh0IjoiY29ucmFkICIsIlNvcnRDb2x1bW4iOiJOYW1lIiwiUGFnZU51bWJlciI6MCwiUGFnZVNpemUiOjUwLCJEYXRhYmFzZSI6IkFuaW1hbHMiLCJBY3RpdmVPbmx5Ijp0cnVlfQ==";

var convert = Convert.FromBase64String(encodedData);
var base64 = Base64.DecodeFromUtf8(Encoding.Default.GetBytes(encodedData));
var base64Url = Base64Url.DecodeFromUtf8(Encoding.Default.GetBytes(encodedData));

Console.WriteLine(convert.SequenceEqual(base64) && base64.SequenceEqual(base64Url));

var original = Encoding.Default.GetString(base64Url);
Console.WriteLine(original);