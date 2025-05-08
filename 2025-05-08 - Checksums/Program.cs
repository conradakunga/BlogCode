using System.Security.Cryptography;
using Serilog;

// Setup Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console().CreateLogger();
//
// Use the SHA256 class
//
{
    using (var sha = SHA256.Create())
    {
        // Compute the hash
        var hash = await sha.ComputeHashAsync(File.OpenRead("/Users/rad/Downloads/HandBrake-1.9.2.dmg"));
        // Get the checksum
        var rawChecksum = BitConverter.ToString(hash);
        // Log raw hash
        Log.Debug("Raw Checksum: {RawChecksum}", rawChecksum);
        // Clean up and convert the casing
        var checksum = rawChecksum.Replace("-", "").ToLower();
        // Log final hash
        Log.Debug("Final Checksum: {Checksum}", checksum);
        Console.WriteLine(checksum);
    }
}

//
// Use the CryptographicOperations clas
//
{
    // Compute the hash
    var hash = await CryptographicOperations.HashDataAsync(HashAlgorithmName.SHA256,
        File.OpenRead("/Users/rad/Downloads/HandBrake-1.9.2.dmg"));
    // Get the checksum
    var rawChecksum = BitConverter.ToString(hash);
    // Log raw hash
    Log.Debug("Raw Checksum: {RawChecksum}", rawChecksum);
    // Clean up and convert the casing
    var checksum = rawChecksum.Replace("-", "").ToLower();
    // Log final hash
    Log.Debug("Final Checksum: {Checksum}", checksum);
    Console.WriteLine(checksum);
}