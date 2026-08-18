using System.Reflection;
using System.Runtime.Loader;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Default root location is {Original}", Assembly.GetExecutingAssembly().Location);

const string customDirectory = @"/User/rad/Documents/plugins/";

AssemblyLoadContext.SetAssemblyLocationOverride((assembly, defaultLocation) =>
{
    // View the default values
    Log.Warning("Original resolved location is {Original}", defaultLocation);

    // Get the assembly name
    var assemblyName = assembly.GetName().Name;

    if (assemblyName is not null)
        return Path.Combine(customDirectory, assemblyName + ".dll");
    return defaultLocation;
});

Log.Information("New resolved location is {Original}", Assembly.GetExecutingAssembly().Location);

// Change the location
AssemblyLoadContext.SetAssemblyLocationOverride((assembly, defaultLocation) =>
{
    // View the default values
    Log.Warning("Original resolved location is {Original}", defaultLocation);

    // Get the assembly name
    var assemblyName = assembly.GetName().Name;

    if (assemblyName is not null)
        return Path.Combine(customDirectory, assemblyName + "2.dll");
    return defaultLocation;
});