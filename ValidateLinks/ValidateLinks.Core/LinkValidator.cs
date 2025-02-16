using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using Serilog;

namespace ValidateLinks.Core;

public class LinkValidator
{
    public async Task<ReadOnlyCollection<ValidatedLink>> ValidateAsync(IEnumerable<string>? urls,
        CancellationToken cancellationToken = default)
    {
        if (urls == null)
            throw new ArgumentException(nameof(urls));

        var urlsToValidate = urls.ToArray();

        // Convert IEnumerable to a concrete type
        // Validate the incoming URLS
        foreach (var url in urlsToValidate)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException(url, nameof(url));
            }
        }

        // Create a thread-safe collection to hold our results
        ConcurrentBag<ValidatedLink> validatedLinks = [];

        // Trim all the URls & remove duplicates
        var validUrls = urlsToValidate.ToArray().Select(x => x.Trim()).Distinct().ToArray();

        // Set up the httpClient
        var client = new HttpClient();
        // Set the default user agent
        client.DefaultRequestHeaders.Add("User-Agent",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X x.y; rv:42.0) Gecko/20100101 Firefox/42.0");

        // Configure parallel options
        var options = new ParallelOptions { MaxDegreeOfParallelism = 33 };

        // Validate links in a loop
        await Parallel.ForEachAsync(validUrls, options,
            async (url, cancel) =>
            {
                var startTime = DateTime.Now;
                try
                {
                    Log.Verbose("Validating {URL}", url);

                    // Send HEAD request
                    var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url), cancel);
                    if (response.IsSuccessStatusCode)
                        Log.Verbose("{URL} validated successfully", url);

                    // Add successfully validated link to collection
                    validatedLinks.Add(new ValidatedLink
                    {
                        Url = url,
                        Error = "",
                        StartTime = TimeOnly.FromDateTime(startTime),
                        EndTime = TimeOnly.FromDateTime(DateTime.Now)
                    });
                }
                catch (InvalidOperationException e)
                {
                    Log.Error(e, "Could not fetch {URL}", url);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "{URL} request failed", url);
                    // Add failed link to collection
                    validatedLinks.Add(new ValidatedLink
                    {
                        Url = url,
                        Error = ex.Message,
                        StartTime = TimeOnly.FromDateTime(startTime),
                        EndTime = TimeOnly.FromDateTime(DateTime.Now)
                    });
                }
            });

        return validatedLinks.ToArray().AsReadOnly();
    }
}