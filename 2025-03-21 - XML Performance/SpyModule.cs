using Bogus;
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
            // Create and configure faker
            var faker = new Faker<Spy>()
                .RuleFor(s => s.Name, f => f.Person.FullName)
                .RuleFor(s => s.DateOfBirth, f => f.Date.Past(50));

            // Delegate the handling via content negotiation
            return resp.Negotiate(faker.Generate(10));
        });
    }
}