using Xunit;

namespace Rad.xUnit.Extensions;

/// <summary>
/// Marks a test as only runnable in macOS
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class MacOSOnlyFactAttribute : FactAttribute
{
    public MacOSOnlyFactAttribute()
    {
        if (!OperatingSystem.IsMacOS())
        {
            Skip = "This is a macOS Only Test";
        }
    }
}