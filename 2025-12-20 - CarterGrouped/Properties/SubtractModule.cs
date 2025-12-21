using Carter;

namespace CarterGrouped.Properties;

public class SubtractModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Subtract", () => "Subtract");
    }
}