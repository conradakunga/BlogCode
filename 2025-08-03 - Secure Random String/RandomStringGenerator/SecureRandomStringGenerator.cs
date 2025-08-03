using System.Security.Cryptography;

namespace Generator;

public static class SecureRandomStringGenerator
{
    public static string GenerateRandomString(int length)
    {
        // Ensure length is at least 1
        ArgumentOutOfRangeException.ThrowIfLessThan(length, 1);

        // Generate string
        var result = new char[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = Constants.Alphabet[RandomNumberGenerator.GetInt32(Constants.Alphabet.Length)];
        }

        return new string(result);
    }

    public static string GenerateRandomString2(int length)
    {
        // Ensure length is at least 1
        ArgumentOutOfRangeException.ThrowIfLessThan(length, 1);

        // Generate a byte array of required length 
        var randomBytes = new byte[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            // Fill the array with random bytes
            rng.GetBytes(randomBytes);
            //Get the corresponding character for each the byte using modulus
            return new string(randomBytes.Select(x => Constants.Alphabet[x % Constants.Alphabet.Length]).ToArray());
        }
    }
}