using System.Buffers.Text;
using Serilog;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// First get the text into a byte array
var textToEncode = "Hello";
// Encode the text
var rawByteArray = Encoding.UTF8.GetBytes(textToEncode);
// Print to console
Log.Information("The encoded representation of {Original} is {Current}", textToEncode,
    Convert.ToBase64String(rawByteArray));

// Get a ReadOnlySpan<byte> of the text
var rawBytes = "Hello"u8;
// Print to console
Log.Information("The encoded representation of {Original} is {Current}", "Hello",
    Convert.ToBase64String(rawBytes));
Log.Information("The url encoded representation of {Original} is {Current}", "Hello",
    Base64Url.EncodeToString(rawBytes));