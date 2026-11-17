using Carter;

namespace QueryCarterAPI;

public class SearchModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapMethods("/", [HttpMethods.Query], (SearchRequest request) =>
        {
            var response =
                $"You requested {request.SearchText} from database {request.Database} sorted by {request.SortColumn}";
            return response;
        });
    }
}