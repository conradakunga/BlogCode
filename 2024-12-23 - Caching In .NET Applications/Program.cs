using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Caching.Memory;

// Define Our Keys

const string allSpiesKey = nameof(allSpiesKey);

// Create an in-memory list to represent a database

Spy[] allSpies =
[
    new Spy("James Bond", 60, "MI-5"),
    new Spy("Eve Moneypenny", 35, "MI-5"),
    new Spy("Harry Pearce", 65, "MI-5"),
    new Spy("Jason Bourne", 45, "CIA"),
    new Spy("Evelyn Salt", 30, "CIA"),
    new Spy("Vesper Lynd", 35, "MI-6"),
    new Spy("Q", 30, "MI-6"),
    new Spy("Ethan Hunt", 45, "IMF"),
    new Spy("Luther Stickell", 48, "IMF"),
    new Spy("Benji Dunn", 36, "IMF"),
    new Spy("Adam Carter", 40, "MI-5"),
    new Spy("Ros Myers", 37, "MI-5")
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

app.Run();

return;

// Local method to simulate database fetch that support cancelling
async Task<Spy[]> GetAllSpiesAsync(CancellationToken token)
{
    // Wait for 5 seconds to simulate work
    await Task.Delay(TimeSpan.FromSeconds(5), token);
    return allSpies;
}