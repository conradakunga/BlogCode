using API;
using FileStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DiskFileStoreSettings>(builder.Configuration.GetSection(nameof(DiskFileStoreSettings)));
var app = builder.Build();

app.MapMethods("/v1/Exists/{id:Guid}", ["Head"],
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
        var id = await store.Upload(file.OpenReadStream(), file.FileName, token);
        // Return the new ID
        return Results.Ok(id);
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

        if (!new FileExtensionContentTypeProvider().TryGetContentType(meta.Name, out var contentType))
        {
            contentType = "application/octet-stream";
        }

        // Return file as attachment
        return Results.File(await store.Download(id, token), contentType, meta.Name, enableRangeProcessing: true);
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

app.Run();