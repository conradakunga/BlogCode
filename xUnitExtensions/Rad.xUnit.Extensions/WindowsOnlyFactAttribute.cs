using Xunit;

namespace Rad.xUnit.Extensions;

/// <summary>
/// Marks a test as only runnable in Windows
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class WindowsOnlyFactAttribute : FactAttribute
{
    public WindowsOnlyFactAttribute()
    {
        if (!OperatingSystem.IsWindows())
        {
            Skip = "This is a Windows Only Test";
        }
    }
}