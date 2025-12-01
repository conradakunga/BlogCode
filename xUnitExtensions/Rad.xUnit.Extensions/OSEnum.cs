namespace Rad.xUnit.Extensions;

[Flags]
public enum OSEnum
{
    Windows = 1,
    macOS = 2,
    Linux = 4,
    Android = 8,
    iOS = 16,
    tvOS = 32,
    watchOS = 64
}