using Flurl;

var client = new HttpClient();

var result = await client.GetStringAsync("https://localhost:5000");

await client.GetStringAsync("https://localhost:" + 5000.ToString());

await client.GetStringAsync($"https://localhost:{5000}");

await client.GetStringAsync($"https://localhost:{5000}/Customers?Height=10&Weight=70");

var query = new Dictionary<string, string>()
{
    {"Height","10"},
    {"Weight" , "70"},
    {"BirthYear", "2000"}
};

// Project the dictionary into a collection of name/value pairs and join them into a string
var queryString = string.Join('&', query.Select(q => $"{q.Key}={q.Value}"));

var builder = new UriBuilder("https", "localhost", 5000, "Customers", $"?{queryString}");

await client.GetStringAsync(builder.Uri);


// Create an anonymous type with our values
var queryParameters = new
{
    Height = 10,
    Weight = 70,
    BirthYear = 2000
};

// Build the base url
var url = "https://localhost:5000/"
    // Append the path
    .AppendPathSegment("Customers")
    // Set the querystring
    .SetQueryParams(queryParameters);
// Invoke the request
await client.GetStringAsync(builder.Uri);


// Build the base url
url = new Url(new UriBuilder("https", "localhost", 5000, "Customers").Uri)
   // Set the querystring
   .SetQueryParams(queryParameters);
// Invoke the request
await client.GetStringAsync(url);
