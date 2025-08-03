namespace Generator;

public static class RandomStringGenerator
{
    public static string GenerateRandomString(int length)
    {
        // Ensure length is at least 1
        ArgumentOutOfRangeException.ThrowIfLessThan(length, 1);

        // Generate string
        return new string(Enumerable.Range(0, length)
            .Select(_ => Constants.Alphabet[Random.Shared.Next(Constants.Alphabet.Length)])
            .ToArray());
    }
}