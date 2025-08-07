using System.Security.Cryptography;

namespace PassGen;

public static class StringExtensions
{
    public static char GetRandomCharacter(this string alphabet)
    {
        return alphabet[RandomNumberGenerator.GetInt32(alphabet.Length)];
    }
}