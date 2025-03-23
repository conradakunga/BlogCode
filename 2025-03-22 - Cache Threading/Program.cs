using LazyCache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting up");

// Create our cache options (default)
var options = new MemoryCacheOptions();
// Create our Memory Cache
var memoryCache = new MemoryCache(options);
// Generate our Lazy Cache
var lazyCache = new CachingService();

Log.Information("Using memory cache");

// Create 10 threads to generate the Thing
await Parallel.ForEachAsync(Enumerable.Range(1, 10), async (item, token) =>
{
    // Crate and cache resource
    var x = await memoryCache.GetOrCreateAsync("Key", async _ =>
    {
        // Perform work here
        return await GenerateThing();
    });
});

// Print result fetched from cache
Log.Information("The cached entry is {Entry}", memoryCache.Get<int>("Key"));

Log.Information("Using Lazy Cache");

// Create 10 threads to generate the Thing
await Parallel.ForEachAsync(Enumerable.Range(1, 10), async (item, token) =>
{
    // Crate and cache resource
    var x = await lazyCache.GetOrAddAsync("Key", async _ =>
    {
        // Perform work here
        return await GenerateThing();
    });
});

// Print result fetched from cache
Log.Information("The cached entry is {Entry}", lazyCache.Get<int>("Key"));


return;

async Task<int> GenerateThing()
{
    // Simulate expensive task
    Log.Information("Generating thing from thread {ThreadId}", Environment.CurrentManagedThreadId);
    await Task.Delay(TimeSpan.FromSeconds(5));
    return Random.Shared.Next();
}