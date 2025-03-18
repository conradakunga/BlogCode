using Carter;
using Carter.Response;

namespace XMLSerialization;

public class SpyModule : ICarterModule
{
    // Add a route
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Set the route path
        app.MapGet("/", (HttpResponse resp) =>
        {
            // Create a collection of spies. This should ideally
            // come from a database
            Spy[] spies =
            [
                new()
                {
                    Name = "James Bond",
                    DateOfBirth = new DateTime(1959, 1, 1)
                },
                new()
                {
                    Name = "Vesper Lynd",
                    DateOfBirth = new DateTime(1960, 12, 1)
                },
            ];
            // Delegate the handling via content negotiation
            return resp.Negotiate(spies);
        });
    }
}