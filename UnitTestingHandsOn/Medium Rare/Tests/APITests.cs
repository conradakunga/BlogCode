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

        // Make a create request

        // Post the request

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

        // Make a create request

        // Post the request and get a response

        // Serialize the response of the new spy

        // Now update

        const string newName = "Evelyn Salt";
        const string newAgency = "CIA";
        var newDateOfBirth = new DateOnly(1980, 1, 1);

        // Create an update request 

        // Post the request and get a response

        //
        // Assert We get back a 204


        // Now fetch the spy again to see if updated
        // Assert
        // 1. The fetched spy should not be null
        // 2. The name and agency should match what we sent

    }

    [Fact]
    public async Task Edit_Spy_That_Does_Not_Exist_Returns_NotFound()
    {
        // Create an update request

        // Post the request for a non-existent spy

        // Check the API returned not found
    }
    
    
    // Test for random
    
    // Test for delete
}