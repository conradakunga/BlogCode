using Carter;

namespace CarterGrouped;

public class Modules : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Configure authorization
        var secured = app.MapGroup("").RequireAuthorization();

        // Add module
        secured.MapGet("/Add", () => "Add");

        // Subtract module
        secured.MapGet("/Subtract", () => "Subtract");

        // First version of the Health Check module
        secured.MapGet("/v1/HealthCheck", () => "OK")
            .AllowAnonymous();

        // Second version of the Health Check module
        app.MapGet("/v2/HealthCheck", () => "OK");
    }
}