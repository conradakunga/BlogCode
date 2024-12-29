var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// The location that uploaded files will be stored
// This ideally should be stored as a setting
const string fileStoreLocation = "/Users/rad/Projects/Temp/Conrad/Uploaded";

// Create the location, if it doesn't exist
if (!Directory.Exists(fileStoreLocation))
    Directory.CreateDirectory(fileStoreLocation);

// The max file size, 5MB
const int maxFileSize = 5 * 1024 * 1024;

// Allowed file extensions
string[] allowedFileExtensions = [".jpg", ".jpeg", ".png", ".gif", ".pdf", ".docx", ".xlsx"];

app.MapPost("/Upload", async (IFormFile file, ILogger<Program> logger) =>
    {
        // Abort for zero length files
        if (file.Length == 0)
        {
            logger.LogWarning("Uploaded file {FileName} is zero length", file.FileName);
            return Results.BadRequest("File is empty");
        }

        // Abort for files larger than the threshold
        if (file.Length > maxFileSize)
        {
            logger.LogWarning("Uploaded file {FileName} is larger than the allowed size", maxFileSize);
            return Results.BadRequest("File larger than the allowed size");
        }

        // Validate the extension. If the extension is NOT in the array of allowed
        // extensions, block it
        var fileExtension = Path.GetExtension(file.FileName);
        if (allowedFileExtensions.All(ext => fileExtension != ext))
        {
            logger.LogWarning("Uploaded file {FileName} is a {Extension} which is blocked", file.FileName,
                fileExtension);
            return Results.BadRequest("Blocked file extension");
        }

        // Build the filename in preparation for writing
        // Ideally, prepend some sort of unique identifier per file
        // To avoid overwriting older uploaded files with the same name
        var storeFileName = Path.Combine(fileStoreLocation, file.FileName);
        // Write the file to disk asynchronously
        await using (var stream = new FileStream(storeFileName, FileMode.Create))
        {
            await file.CopyToAsync(stream, CancellationToken.None);
        }

        logger.LogInformation("Upload of file {FileName} was successful", file.FileName);
        return Results.Ok($"Uploaded file {file.FileName} successfully");
    }).DisableAntiforgery()
    .WithName("UploadFile");

app.Run();