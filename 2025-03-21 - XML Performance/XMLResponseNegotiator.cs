using System.Net.Mime;
using System.Runtime.Serialization;
using Carter;
using Microsoft.IO;
using Microsoft.Net.Http.Headers;

namespace XMLSerialization;

public sealed class XmlResponseNegotiator : IResponseNegotiator
{
    private readonly RecyclableMemoryStreamManager _streamManager;

    public XmlResponseNegotiator(RecyclableMemoryStreamManager streamManager)
    {
        _streamManager = streamManager;
    }

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

        // Acquire the shared memory stream
        await using (var ms = _streamManager.GetStream())
        {
            // Write the object to the stream
            serializer.WriteObject(ms, model);

            // Set the stream position to 0, for writing to the response
            ms.Position = 0;

            // Write the memory stream to the response Body
            await ms.CopyToAsync(res.Body, ct);
        }
    }
}