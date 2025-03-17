using System;
using Carter;
using Carter.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace XMLSerialization;

public class SpyModule : ICarterModule
{
    // Add a route
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Set the route path
        app.MapGet("/", (HttpResponse resp) =>
        {
            // Create object
            var spy = new Spy()
            {
                Name = "James Bond",
                DateOfBirth = new DateTime(1960, 1, 1)
            };

            // Delegate the handling via content negotiation
            return resp.Negotiate(spy);
        });
    }
}