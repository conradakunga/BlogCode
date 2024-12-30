using API;
using FileStore.Implementations;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    // Setup logging
    builder.Services.AddSerilog();
    // Set up the upload limit at infrastructure level
    builder.Services.Configure<FormOptions>(options =>
    {
        // Default to 5MB
        options.MultipartBodyLengthLimit = 5 * 1024 * 1024;
    });
    builder.Services.Configure<DiskFileStoreSettings>(builder.Configuration.GetSection(nameof(DiskFileStoreSettings)));
    var app = builder.Build();

    app.MapMethods("/v1/Exists/{id:Guid}", [HttpMethod.Head.Method],
        async (Guid id, [FromHeader] string userID, IOptions<DiskFileStoreSettings> settings) =>
        {
            var store = new DiskFileStore(settings.Value.Path, userID);
            if (await store.Exists(id))
            {
                return Results.Ok();
            }

            return Results.NotFound();
        });

    app.MapDelete("/v1/Delete/{id:Guid}",
        async (Guid id, [FromHeader] string userID, IOptions<DiskFileStoreSettings> settings) =>
        {
            var store = new DiskFileStore(settings.Value.Path, userID);
            if (await store.Exists(id))
            {
                await store.Delete(id);
                return Results.Ok();
            }

            return Results.NotFound();
        });

    app.MapGet("/Info", () => Results.Ok("Running"));

    app.MapPost("/v1/Upload/",
        async (IFormFile file, [FromHeader] string userID, CancellationToken token,
            IOptions<DiskFileStoreSettings> settings) =>
        {
            if (file.Length == 0)
                return Results.BadRequest();

            var store = new DiskFileStore(settings.Value.Path, userID);
            var fileMetaData = await store.Upload(file.OpenReadStream(), file.FileName, token);
            // Return the metadata
            return Results.Ok(fileMetaData);
        }).DisableAntiforgery();

    app.MapGet("/v1/Download/{id:Guid}",
        async (Guid id, [FromHeader] string userID, CancellationToken token,
            IOptions<DiskFileStoreSettings> settings) =>
        {
            var store = new DiskFileStore(settings.Value.Path, userID);
            if (!await store.Exists(id))
                return Results.NotFound();

            // Get the metadata
            var meta = await store.GetMetaData(id, token);

            if (!new FileExtensionContentTypeProvider().TryGetContentType(meta.FileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            // Return file as attachment
            return Results.File(await store.Download(id, token), contentType, meta.FileName,
                enableRangeProcessing: true);
        });

    app.MapGet("/v1/MetaData/{id:Guid}",
        async (Guid id, [FromHeader] string userID, CancellationToken token,
            IOptions<DiskFileStoreSettings> settings) =>
        {
            var store = new DiskFileStore(settings.Value.Path, userID);
            if (!await store.Exists(id))
                return Results.NotFound();

            return Results.Ok(await store.GetMetaData(id, token));
        });

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}