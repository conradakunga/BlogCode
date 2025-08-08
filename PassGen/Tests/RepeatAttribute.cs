using System.Reflection;
using Xunit.Sdk;

namespace Tests;

public sealed class RepeatAttribute : DataAttribute
{
    private readonly int _count;

    public RepeatAttribute(int count)
    {
        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Repeat count must be greater than 0."
            );
        }

        _count = count;
    }

    public override IEnumerable<object[]> GetData(MethodInfo _)
    {
        foreach (var iteration in Enumerable.Range(0, _count))
        {
            yield return [iteration];
        }
    }
}