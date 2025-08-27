using System.Net;
using System.Net.Http.Json;
using AwesomeAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using UnitTestingLogic;

namespace Tests;

public class APITests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public APITests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Create_Spy_Works()
    {
        // Our test data
        const string name = "James Bond";
        const string agency = "Mi5";
        var dateOfBirth = new DateOnly(1950, 1, 1);

        var create = new CreateSpyRequest
        {
            Name = name,
            Agency = agency,
            DateOfBirth = dateOfBirth,
        };

        // Post the request
        var response = await _client.PostAsJsonAsync("/Spy", create);

        // Assert
        // 1. We get back a 201
        // 2. The created spy should not be null
        // 3. The name and agency should match what we sent

    }

    [Fact]
    public async Task Edit_Spy_Works()
    {
        // Our test data
        const string name = "James Bond";
        const string agency = "Mi5";
        var dateOfBirth = new DateOnly(1950, 1, 1);

        var create = new CreateSpyRequest
        {
            Name = name,
            Agency = agency,
            DateOfBirth = dateOfBirth,
        };

        // Post the request
        var response = await _client.PostAsJsonAsync("/Spy", create);
        var newSpy = await response.Content.ReadFromJsonAsync<Spy>();

        // Now update

        const string newName = "Evelyn Salt";
        const string newAgency = "CIA";
        var newDateOfBirth = new DateOnly(1980, 1, 1);

        var request = new UpdateSpyRequest
        {
            Name = newName,
            Agency = newAgency,
            DateOfBirth = newDateOfBirth,
        };

        // Post the request

        var updateResponse = await _client.PutAsJsonAsync($"/Spy/{newSpy!.SpyID}", request);

        //
        // Assert
        // 1. We get back a 204
        // 2. The fetched spy should not be null
        // 3. The name and agency should match what we sent

        // Now fetch again to see if updated

    }

    [Fact]
    public async Task Edit_Spy_That_Does_Not_Exist_Returns_NotFound()
    {
        var request = new UpdateSpyRequest
        {
            Name = "James Bond",
            Agency = "CIA",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
        };

        // Post the request

        var updateResponse = await _client.PutAsJsonAsync($"/Spy/{Guid.NewGuid()}", request);
        
        // Check the API returned not found
    }
}