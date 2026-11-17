using HttpClientQuery;

var req = new SearchRequest
{
    SearchText = "conrad ",
    SortColumn = "Name",
    PageNumber = 0,
    PageSize = 50,
    Database = "Animals",
    ActiveOnly = true
};

// Create our HttpClient
var client = new HttpClient();

// Construct our HttpRequest
var request = new HttpRequestMessage(HttpMethod.Query, "http://localhost:5076");

// Set the content
request.Content = JsonContent.Create(req);

// Sed the request
var response = await client.SendAsync(request);

// Extract the content form the response
var responseContent = await response.Content.ReadAsStringAsync();

Console.WriteLine(responseContent);