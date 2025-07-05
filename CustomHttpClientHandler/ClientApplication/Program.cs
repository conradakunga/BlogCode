// Define (or fetch) our values

const string header = "x-custom-lower-case-header";
const string value = "myValue";

var client = new HttpClient(new CaseSensitiveHeaderHandler(header, value));

var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5068/");
await client.SendAsync(request);