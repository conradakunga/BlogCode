using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
{
    // Define root location
    const string root = "/Users/rad/Projects/blog";

    // Set upload path
    const string uploadPath = root + "/uploads/logo.jpg";

    Log.Information(uploadPath);
}

{
    // Define root location
    const string root = "/Users/rad/Projects/blog";

    // Set upload path
    const string uploadPath = root + "/uploads/" + "../../../../logo.jpg";

    Log.Information(uploadPath);

    Log.Information(new DirectoryInfo(uploadPath).FullName);
}
{
    const string root = "/Users/rad/Projects/blog";

    // Set upload path
    var illegalUploadPath = Path.Combine(root, "uploads", "../../../../logo.jpg");
    var legalUploadPath = Path.Combine(root, "uploads", "logo.jpg");

    Log.Information(illegalUploadPath);
    Log.Information(legalUploadPath);

    // verify the path
    var legalInfo = new DirectoryInfo(legalUploadPath);
    var illegalInfo = new DirectoryInfo(illegalUploadPath);

    // Verify the parent
    if (legalInfo.Parent!.Parent!.FullName == root)
        Log.Information($"'{legalInfo}' is a valid path");
    if (illegalInfo.Parent!.Parent!.FullName != root)
        Log.Error($"'{legalInfo}' is an invalid valid path");
}