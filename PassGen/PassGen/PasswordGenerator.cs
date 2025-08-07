using Serilog;

namespace PassGen;

public static class PasswordGenerator
{
    public static string GeneratePassword(int numbers, int symbols, int passwordLength)
    {
        // Ensure the numbers and symbols are valid
        ArgumentOutOfRangeException.ThrowIfNegative(numbers);
        ArgumentOutOfRangeException.ThrowIfNegative(symbols);

        // Ensure the password lenght is legit
        ArgumentOutOfRangeException.ThrowIfLessThan(passwordLength, Constants.MinimumPasswordLength);
        
        // Ensure the number and symbols are congruent with requested password length
        if (numbers + symbols > passwordLength)
            throw new ArgumentException("numbers and symbols length cannot be greater than requested password length");

        var numericString = new string(Enumerable.Range(0, numbers)
            .Select(x => Constants.NumericAlphabet.GetRandomCharacter())
            .ToArray());
        Log.Debug("Numeric String {String}", numericString);

        var symbolString = new string(Enumerable.Range(0, symbols)
            .Select(x => Constants.SymbolAlphabet.GetRandomCharacter())
            .ToArray());
        Log.Debug("Symbol String: {String}", symbolString);

        var characterString = new string(Enumerable.Range(0, passwordLength - numbers - symbols)
            .Select(x => Constants.CharacterAlphabet.GetRandomCharacter())
            .ToArray());
        Log.Debug("Character String: {String}", characterString);

        var rawPassword = $"{numericString}{characterString}{symbolString}";

        Log.Debug("Raw password: {String}", rawPassword);

        return new string(rawPassword.OrderBy(x => Random.Shared.Next()).ToArray());
    }
}