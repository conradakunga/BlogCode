using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


// Create the HttpClient
var client = new HttpClient();

// Set the base address to simplify maintenance & requests
client.BaseAddress = new Uri("https://localhost:5001/");

// Create an object
var person = new Person() { Names = "James Bond", DateOfBirth = new DateTime(1990, 1, 1) };

// Serialize class into JSON
var payload = JsonSerializer.Serialize(person);

// Wrap our JSON inside a StringContent object
var content = new StringContent(payload, Encoding.UTF8, "application/json");

// Post to the endpoint
var response = await client.PostAsync("Create", content);

// Create a second person
var otherPerson = new Person() { Names = "Jason Bourne", DateOfBirth = new DateTime(2000, 1, 1) };

var ctx = new CancellationTokenSource().Token;

// Post to the endpoint with a cancellation token
response = await client.PostAsJsonAsync("Create", otherPerson, ctx);

//
// Post with custom serialization options
//

// Configure required JSON serialization options
var options = new JsonSerializerOptions()
{
    AllowTrailingCommas = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    IgnoreReadOnlyProperties = true,
    NumberHandling = JsonNumberHandling.WriteAsString,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
};

// Post to the endpoint with custom options
response = await client.PostAsJsonAsync("Create", otherPerson, options);



public class Person
{
    public string Names { get; set; }
    public DateTime DateOfBirth { get; set; }
}