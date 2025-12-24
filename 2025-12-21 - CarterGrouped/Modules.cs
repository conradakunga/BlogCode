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
    }
}