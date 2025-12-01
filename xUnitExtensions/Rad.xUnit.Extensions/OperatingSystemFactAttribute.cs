using Xunit;

namespace Rad.xUnit.Extensions;

/// <summary>
/// Check if the test can be run on passed operating system
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class OperatingSystemFactAttribute : FactAttribute
{
    public OperatingSystemFactAttribute(OSEnum os)
    {
        var isMatch = (os.HasFlag(OSEnum.Windows) && OperatingSystem.IsWindows()) ||
                      (os.HasFlag(OSEnum.macOS) && OperatingSystem.IsMacOS()) ||
                      (os.HasFlag(OSEnum.Android) && OperatingSystem.IsAndroid()) ||
                      (os.HasFlag(OSEnum.iOS) && OperatingSystem.IsIOS()) ||
                      (os.HasFlag(OSEnum.tvOS) && OperatingSystem.IsTvOS()) ||
                      (os.HasFlag(OSEnum.watchOS) && OperatingSystem.IsWatchOS());

        if (!isMatch)
        {
            Skip = $"{os} is supported. Current operating system does not match.";
        }
    }
}