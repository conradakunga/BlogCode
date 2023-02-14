// Get the folder location
var folderLocation = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Incomplete";
Console.WriteLine(folderLocation);
// Create the folder
Directory.CreateDirectory(folderLocation);

folderLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Incomplete");
Console.WriteLine(folderLocation);

folderLocation = Path.Combine(folderLocation, "Active");
Console.WriteLine(folderLocation);

folderLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Incomplete", "Active", "2023", "January");
Console.WriteLine(folderLocation);

folderLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Incomplete", "Active", @"C:\2023", "January");
Console.WriteLine(folderLocation);