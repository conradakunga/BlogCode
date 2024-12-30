using System.Net.Mime;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// The location that uploaded files will be stored
// This ideally should be stored as a setting
const string fileStoreLocation = "/Users/rad/Projects/Temp/Conrad/Uploaded";

// Create the location, if it doesn't exist
if (!Directory.Exists(fileStoreLocation))
    Directory.CreateDirectory(fileStoreLocation);

// Allowed file extensions
string[] allowedFileExtensions = [".jpg", ".jpeg", ".png", ".gif", ".pdf", ".docx", ".xlsx"];

app.MapGet("/Download/{fileName}", (string fileName, ILogger<Program> logger) =>
    {
        var fileExtension = Path.GetExtension(fileName);
        if (!allowedFileExtensions.Contains(fileExtension))
        {
            logger.LogWarning("Download file {FileName} is a {Extension} which is blocked", fileName,
                fileExtension);
            return Results.BadRequest("Blocked file extension");
        }

        // Build the path to the download file
        var storeFileName = Path.Combine(fileStoreLocation, Path.GetFileName(fileName));

        // Check if file exists
        if (!File.Exists(storeFileName))
        {
            logger.LogWarning("File {FileName} was not found", fileName);
            return Results.NotFound($"{fileName} not found");
        }

        // Determine the content type for the extension, defaulting to "application/ octet-stream"
        if (!new FileExtensionContentTypeProvider().TryGetContentType(fileName, out var contentType))
        {
            contentType = MediaTypeNames.Application.Octet;
        }

        // Open a stream to the file
        var stream = new FileStream(storeFileName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096,
            true);
        // Return file as attachment asynchronously in chunks directly to browser
        return Results.File(stream, contentType, enableRangeProcessing: true);
    })
    .WithName("DownloadFile");

app.MapGet("/DownloadAttachment/{fileName}",
        (string fileName, ILogger<Program> logger) =>
        {
            var fileExtension = Path.GetExtension(fileName);
            if (!allowedFileExtensions.Contains(fileExtension))
            {
                logger.LogWarning("Download file {FileName} is a {Extension} which is blocked", fileName,
                    fileExtension);
                return Results.BadRequest("Blocked file extension");
            }

            //
            // Build the path to the download file
            //

            // First, sanitize the filename to prevent a path traversal attach
            fileName = Path.GetFileName(fileName);
            var storeFileName = Path.Combine(fileStoreLocation, fileName);

            // Check if file exists
            if (!File.Exists(storeFileName))
            {
                logger.LogWarning("File {FileName} was not found", fileName);
                return Results.NotFound($"{fileName} not found");
            }

            // Determine the content type for the extension, defaulting to "application/ octet-stream"
            if (!new FileExtensionContentTypeProvider().TryGetContentType(fileName, out var contentType))
            {
                contentType = MediaTypeNames.Application.Octet;
            }

            // Open a stream to the file
            var stream = new FileStream(storeFileName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096,
                true);
            // Return file as attachment asynchronously in chunks. Setting the filename
            // sets the content-disposition header to attachment
            return Results.File(stream, contentType, fileName, enableRangeProcessing: true);
        })
    .WithName("DownloadFileAsAttachment");

app.Run();