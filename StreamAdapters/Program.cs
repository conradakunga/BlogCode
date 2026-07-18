// Get our data

using System.Text;

var data =
    """
    The quick brown fox
    mightily jumped over
    the brown dog very
    very bigly
    """;

// Convert our data a byte array
var dataInBytes = Encoding.Default.GetBytes(data);

// Convert our byte array into a memory stream
var dataStream = new MemoryStream(dataInBytes);

// Directly create a stream
var directDataStream = new StringStream(data, Encoding.UTF8);