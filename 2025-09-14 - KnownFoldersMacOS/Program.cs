// Get the home location
string homeLocation = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
// Build the download path
string downloadLocation = Path.Combine(homeLocation, "Downloads");
// Check that the location exists
if (Directory.Exists(downloadLocation))
{
    Console.WriteLine($"The Downloads location is '{downloadLocation}'");
}
else
{
    Console.WriteLine("Could not find Downloads location");
}