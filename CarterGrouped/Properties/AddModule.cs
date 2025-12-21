using Carter;

namespace CarterGrouped.Properties;

public class AddModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Add", () => "Add");
    }
}