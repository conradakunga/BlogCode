using Carter;

namespace CarterGrouped;

public class HealthCheckModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/HealthCheck", () => "OK")
            .AllowAnonymous();
    }
}