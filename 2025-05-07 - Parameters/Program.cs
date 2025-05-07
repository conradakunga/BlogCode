using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using SkiaSharp;

const string connectionString = "data source=.;database=Spies;uid=sa;pwd=YourStrongPassword123;Encrypt=false";

var builder = WebApplication.CreateBuilder(args);

// Setup DI to inject a Sql Server connection
builder.Services.AddSingleton<SqlConnection>(_ => new SqlConnection(connectionString));

var app = builder.Build();

app.MapPost("/Countries", async (SqlConnection cn, ILogger<Program> logger, CreateCountryRequest request) =>
{
    var param = new DynamicParameters();
    param.Add("Name", request.Name);
    param.Add("CountryID", dbType: DbType.Guid, direction: ParameterDirection.Output);

    var result = await cn.ExecuteAsync("[Countries.Insert]", param);

    // Fetch the new ID
    var id = param.Get<Guid>("CountryID");
    logger.LogInformation("New Country ID: {ID}", id);

    if (result > 0)
        return Results.Ok();
    return Results.StatusCode(StatusCodes.Status304NotModified);
});

app.MapGet("/Countries", async (SqlConnection cn) =>
{
    var result = await cn.QueryAsync<Country>("SELECT * FROM Countries");
    return Results.Ok(result);
});

app.MapPost("/Bureaus", async (SqlConnection cn, CreateBureauRequest request) =>
{
    byte[]? imageData = null;
    // Check if there was text
    if (!string.IsNullOrEmpty(request.LogoText))
    {
        // Generate a logo from the logo text

        // Create bitmap
        using var bitmap = new SKBitmap(500, 100);
        // Create canvas from bitmap
        using var canvas = new SKCanvas(bitmap);
        // Set the background colour
        canvas.Clear(SKColors.White);
        // Create a font - use the default
        var font = new SKFont
        {
            Typeface = SKTypeface.Default,
            Size = 35
        };
        // Create and configure paint object
        using var paint = new SKPaint();
        paint.Color = SKColors.Red;
        paint.IsAntialias = true;
        // Draw the text
        canvas.DrawText(request.LogoText, 20, 50, font, paint);
        // Get an image
        using var image = SKImage.FromBitmap(bitmap);
        // Encode the image as a PNG at full quality
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        // Get the bytes
        imageData = data.ToArray();
    }

    // Set the parameters
    var param = new DynamicParameters();
    param.Add("Name", request.Name);
    param.Add("BureauID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    param.Add("Logo", imageData, dbType: DbType.Binary);

    var result = await cn.ExecuteAsync("[Bureaus.Insert]", param);

    if (result > 0)
        return Results.Ok();
    return Results.StatusCode(StatusCodes.Status304NotModified);
});
app.Run();