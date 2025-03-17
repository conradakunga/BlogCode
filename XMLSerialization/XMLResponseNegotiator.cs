using System.IO;
using System.Net.Mime;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Carter;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

public class XMLResponseNegotiator : IResponseNegotiator
{
    // Establish if the client had indicated it will accept xml
    public bool CanHandle(MediaTypeHeaderValue accept)
    {
        return accept.MatchesMediaType(MediaTypeNames.Application.Xml);
    }

    // Handle the request
    public async Task Handle<T>(HttpRequest req, HttpResponse res, T model, CancellationToken ct)
    {
        // Set the content type
        res.ContentType = MediaTypeNames.Application.Xml;

        // Create a serializer for the model type, T
        var serializer = new DataContractSerializer(typeof(T));

        // Create a memory stream
        using (var ms = new MemoryStream())
        {
            // Write the object
            serializer.WriteObject(ms, model);

            // Set the stream position to 0, for writing to the response
            ms.Position = 0;

            // Write the memory stream to the response Body
            await ms.CopyToAsync(res.Body, ct);
        }
    }
}