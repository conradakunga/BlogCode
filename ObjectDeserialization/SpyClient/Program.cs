using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using SpyLogic;

const string url = "http://localhost:5207/ListSpiesError";
var client = new HttpClient();
{
    try
    {
        // Fetch a response from the end point
        var response = await client.GetStringAsync(url);
        // Configure our json serializer
        var options = JsonSerializerOptions.Web;
        // Deserialize the response
        var spies = JsonSerializer.Deserialize<Spy[]>(response, options);
        foreach (var spy in spies)
        {
            Console.WriteLine($"Firstname: {spy.FirstName}, Surname: {spy.Surname}, Age: {spy.Age}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"There was an error: {ex.Message}");
    }
}
{
    try
    {
        // Fetch and deserialize spies
        var spies = await client.GetFromJsonAsync<Spy[]>(url);
        foreach (var spy in spies)
        {
            Console.WriteLine($"Firstname: {spy.FirstName}, Surname: {spy.Surname}, Age: {spy.Age}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"There was an error: {ex.Message}");
    }
}
{
    // Fetch a response from the end point
    HttpResponseMessage response = await client.GetAsync(url);
    // Check if the response was a success
    if (response.IsSuccessStatusCode)
    {
        // Fetch the actual response
        var responseString = await response.Content.ReadAsStringAsync();
        // Configure our json serializer
        var options = JsonSerializerOptions.Web;
        // Deserialize the response
        var spies = JsonSerializer.Deserialize<Spy[]>(responseString, options);
        foreach (var spy in spies)
        {
            Console.WriteLine($"Firstname: {spy.FirstName}, Surname: {spy.Surname}, Age: {spy.Age}");
        }
    }
    else
    {
        // Fetch the actual problem
        var problemString = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Received unsuccessful status code: {response.StatusCode}, the issue being {problemString}");
    }
}
{
    // Fetch a response from the end point
    HttpResponseMessage response = await client.GetAsync("http://localhost:5207/ListSpiesError");
    // Check if the response was a success
    switch (response.StatusCode)
    {
        case HttpStatusCode.OK:
            // Fetch the actual response
            var responseString = await response.Content.ReadAsStringAsync();
            // Configure our json serializer
            var options = JsonSerializerOptions.Web;
            // Deserialize the response
            var spies = JsonSerializer.Deserialize<Spy[]>(responseString, options);
            foreach (var spy in spies)
            {
                Console.WriteLine($"Firstname: {spy.FirstName}, Surname: {spy.Surname}, Age: {spy.Age}");
            }

            break;
        case HttpStatusCode.InternalServerError:
            // Fetch the actual problem
            var problemString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(
                $"There was an error on the server, the issue being {problemString}");
            break;

        // Add more status codes and their processing blocks here
        default:
            Console.WriteLine(
                $"Received status code: {response.StatusCode}");
            break;
    }
}