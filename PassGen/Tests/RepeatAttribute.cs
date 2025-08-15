using System.Reflection;
using Xunit.Sdk;

namespace Tests;

/// <summary>
/// Runs tests multiple times
/// </summary>
public sealed class RepeatAttribute : DataAttribute
{
    private readonly int _count;

    /// <summary>
    /// Number of times to run the tests
    /// </summary>
    /// <param name="count"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public RepeatAttribute(int count)
    {
        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Repeat count must be greater than 0."
            );
        }

        _count = count;
    }

    /// <summary>
    /// Returns an enumerable to be used by the test runner
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    public override IEnumerable<object[]> GetData(MethodInfo _)
    {
        foreach (var iteration in Enumerable.Range(1, _count))
        {
            yield return [iteration];
        }
    }
}