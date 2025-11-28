using Xunit;

namespace Rad.xUnit.Extensions;

/// <summary>
/// Marks a test as only runnable in Linux
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class LinuxOnlyFactAttribute : FactAttribute
{
    public LinuxOnlyFactAttribute()
    {
        if (!OperatingSystem.IsLinux())
        {
            Skip = "This is a Linux Only Test";
        }
    }
}