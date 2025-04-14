using System.Collections;

namespace Calculator.Tests;

public class AdditionTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 0, 0, 0 };
        yield return new object[] { 0, 1, 1 };
        yield return new object[] { 2, 2, 4 };
        yield return new object[] { -1, -1, -2 };
        yield return new object[] { -1, 1, 0 };
        yield return new object[] { 100, 100, 200 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}