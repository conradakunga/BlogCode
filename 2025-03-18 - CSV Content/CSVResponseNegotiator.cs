using System.Globalization;
using System.Net.Mime;
using Carter;
using CsvHelper;
using Microsoft.Net.Http.Headers;

public class CSVResponseNegotiator : IResponseNegotiator
{
    // Establish if the client had indicated it will accept csv
    public bool CanHandle(MediaTypeHeaderValue accept)
    {
        return accept.MatchesMediaType(MediaTypeNames.Text.Csv);
    }

    // Handle the request
    public async Task Handle<T>(HttpRequest req, HttpResponse res, T model, CancellationToken ct)
    {
        // Set the content type
        res.ContentType = MediaTypeNames.Text.Csv;

        // Verify that the model coming in is an IEnumerable
        if (model is IEnumerable<object> data)
        {
            // Setup our csv writer to write to the response body
            await using (var writer = new StreamWriter(res.Body)) 
            // Configure the CSV writer
            await using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Write the data to the stream
                await csv.WriteRecordsAsync(data, ct);
            }
        }
    }
}