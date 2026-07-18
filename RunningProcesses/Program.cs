using System.Diagnostics;


{
    try
    {
        var process = Process.GetProcessById(99999);

        Console.WriteLine($"Process name: {process.ProcessName}");
    }
    catch (Exception e)
    {
        Console.WriteLine("Could not load process!");
    }
}

{
    if (Process.TryGetProcessById(99999, out var process))
    {
        // Do stuff with our process here
        Console.WriteLine($"Process name: {process.ProcessName}");
    }
    else
    {
        Console.WriteLine("Could not load process!");
    }
}