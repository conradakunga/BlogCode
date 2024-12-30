using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Caching.Memory;

// Define Our Keys

const string allSpiesKey = nameof(allSpiesKey);

// Create an in-memory list to represent a database

List<Spy> allSpies =
[
    new Spy(1, "James Bond", 60, "MI-5"),
    new Spy(2, "Eve Moneypenny", 35, "MI-5"),
    new Spy(3, "Harry Pearce", 65, "MI-5"),
    new Spy(4, "Jason Bourne", 45, "CIA"),
    new Spy(5, "Evelyn Salt", 30, "CIA"),
    new Spy(6, "Vesper Lynd", 35, "MI-6"),
    new Spy(7, "Q", 30, "MI-6"),
    new Spy(8, "Ethan Hunt", 45, "IMF"),
    new Spy(9, "Luther Stickell", 48, "IMF"),
    new Spy(10, "Benji Dunn", 36, "IMF"),
    new Spy(11, "Adam Carter", 40, "MI-5"),
    new Spy(12, "Ros Myers", 37, "MI-5")
];

var builder = WebApplication.CreateBuilder(args);

// Register the cache with dependency injection
builder.Services.AddMemoryCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    // The Redis connection string
    options.Configuration = "localhost:6379";
});

#pragma warning disable EXTEXP0018
builder.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        Expiration = TimeSpan.FromMinutes(5),
        LocalCacheExpiration = TimeSpan.FromMinutes(5)
    };
});
#pragma warning restore EXTEXP0018

var app = builder.Build();

app.MapGet("/GetSpiesMemoryCache", async (IMemoryCache cache, ILogger<Program> logger, CancellationToken token) =>
    {
        return await cache.GetOrCreateAsync(allSpiesKey, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            // Log that we are populating from the 'database'
            logger.LogInformation("Populating from the database");
            // Local function to simulate cancellable query to database
            return GetAllSpiesAsync(token);
        });
    })
    .WithName("GetSpiesFromMemoryCache");

app.MapGet("/GetSpiesDistributedCache",
        async (IDistributedCache cache, ILogger<Program> logger, CancellationToken token) =>
        {
            var spyData = await cache.GetAsync(allSpiesKey, token);

            if (spyData == null)
            {
                logger.LogInformation("No spies in cache. Loading from database ...");
                // Could not find in cache. Load from 'database'
                var spies = await GetAllSpiesAsync(token);
                // Serialize to JSON and encode into a byte array
                spyData = Encoding.Default.GetBytes(JsonSerializer.Serialize(spies));
                // Update the cache
                await cache.SetAsync(allSpiesKey, spyData, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                }, token);
            }

            // If we are here, we found data in the cache
            logger.LogInformation("Populating from the cache");
            return JsonSerializer.Deserialize<Spy[]>(spyData);
        })
    .WithName("GetSpiesFromDistributedCache");

app.MapGet("/GetSpiesHybridCache",
        async (HybridCache cache, ILogger<Program> logger, CancellationToken token) =>
        {
            // Create tags
            string[] tags = ["Sunday", "December"];
            // You can override the global entry options here
            var localEntryOptions = new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromMinutes(5),
                LocalCacheExpiration = TimeSpan.FromMinutes(5)
            };


            return await cache.GetOrCreateAsync(allSpiesKey, async localCancellationToken =>
                {
                    logger.LogInformation("Populating from the database");
                    return await GetAllSpiesAsync(localCancellationToken);
                },
                localEntryOptions,
                tags,
                cancellationToken: token);
        })
    .WithName("GetSpiesFromHybridCache");

app.MapGet("/ViewSpyHybridCache/{id:int}", (int id) =>
{
    // Try and find the spy in the cache
    var spy = allSpies.SingleOrDefault(x => x.Id == id);

    // If null, wasn't found
    if (spy == null)
        return Results.NotFound();

    return Results.Ok(spy);
}).WithName("ViewSpyFromCache");

app.MapPost("/CreateSpyHybridCache",
        async (CreateSpyRequest request, HybridCache cache, CancellationToken token) =>
        {
            // Add the spy to the list. The ID generation is simplistic and should not be done
            // like this in production as it isn't thread-safe
            var newSpy = new Spy(allSpies.Count + 1, request.FullNames, request.Age, request.Service);
            await AddSpyAsync(newSpy, token);
            // Invalidate the cache
            await cache.RemoveAsync(allSpiesKey, token);
            // Here we should redirect to the new Spy
            return Results.Created($"Spies/{newSpy.Id}", newSpy);
        })
    .WithName("CreateSpyWithHybridCache");

app.MapDelete("/DeleteSpyHybridCache/{id:int}",
        async (int id, HybridCache cache, CancellationToken token) =>
        {
            var removedSpies = allSpies.RemoveAll(x => x.Id == id);

            // Check of any spies were removed
            if (removedSpies == 0)
                return Results.NotFound();

            // If we are here, a spy was removed. Invalidate the cache
            await cache.RemoveAsync(allSpiesKey, token);
            // Return status
            return Results.NoContent();
        })
    .WithName("DeleteSpyWithHybridCache");
app.Run();

return;

// Local method to simulate database fetch that support cancelling
async Task<Spy[]> GetAllSpiesAsync(CancellationToken token)
{
    // Wait for 5 seconds to simulate work
    await Task.Delay(TimeSpan.FromSeconds(5), token);
    return allSpies.ToArray();
}

async Task AddSpyAsync(Spy spy, CancellationToken token)
{
    // Wait for 5 seconds to simulate work
    await Task.Delay(TimeSpan.FromSeconds(5), token);
    allSpies.Add(spy);
}