var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapMethods("/", [HttpMethods.Query],
    (SearchRequest request) =>
    {
        var response =
            $"You requested {request.SearchText} from database {request.Database} sorted by {request.SortColumn}";
        return response;
    });

app.Run();