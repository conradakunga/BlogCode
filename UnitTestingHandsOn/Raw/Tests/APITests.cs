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
    }

    [Fact]
    public async Task Edit_Spy_Works()
    {
    }

    [Fact]
    public async Task Edit_Spy_That_Does_Not_Exist_Returns_NotFound()
    {
    }
}