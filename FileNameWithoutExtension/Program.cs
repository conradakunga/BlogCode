using System.Text.RegularExpressions;

var filename = "Potato.doc";

var info = new FileInfo(filename);

Console.WriteLine($"The name is '{info.Name}'");
Console.WriteLine($"The extension is '{info.Extension}'");

// Use string.Replace
var name = info.Name;
var extension = info.Extension;

var fileNameWithoutExtension = name.Replace(extension, "");

Console.WriteLine($"The name without extension is '{fileNameWithoutExtension}'");

// Use regex. But really, don't do it this way!
fileNameWithoutExtension = Regex.Match(filename, @"(?<name>\w+)\.").Groups["name"].Value;
Console.WriteLine($"The name without extension is '{fileNameWithoutExtension}'");

// Use Path.GetFileNameWithoutExtension
fileNameWithoutExtension = Path.GetFileNameWithoutExtension(name);
Console.WriteLine($"The name without extension is '{fileNameWithoutExtension}'");