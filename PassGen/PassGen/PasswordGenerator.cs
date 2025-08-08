using Serilog;

namespace PassGen;

public static class PasswordGenerator
{
    public static string GenerateMemorablePassword()
    {
        // Temporary list to store generated password elements
        List<string> passwords = new List<string>(Constants.MemorableWordCount);

        // Load the words from file
        var words = File.ReadAllLines("Content/words.txt");

        // Create a dictionary with 8 elements
        var wordDictionary = new Dictionary<int, string[]>(Constants.MaximumMemorableWordLength);

        // Populate the dictionary
        foreach (var wordLength in Enumerable.Range(0, Constants.MaximumMemorableWordLength))
        {
            // Check if the word length is between 3 and 8
            if (wordLength >= Constants.MinimumMemorableWordLength)
            {
                // Query the lines for words of corresponding length, and add to the
                // corresponding dictionary entry array
                wordDictionary[wordLength] = words.Where(x => x.Length == wordLength).ToArray();
            }
            else
            {
                // For 0, 1 and 2, we don't need words of this length. Empty list
                wordDictionary[wordLength] = [];
            }
        }

        foreach (var _ in Enumerable.Range(0, Constants.MemorableWordCount))
        {
            // Get a random number between 3 and 8
            var length = Random.Shared.Next(Constants.MinimumMemorableWordLength, Constants.MaximumMemorableWordLength);

            // Pick a random word with corresponding length from dictionary
            passwords.Add(wordDictionary[length][Random.Shared.Next(wordDictionary[length].Length)]);
        }

        // Join the elements and return
        return string.Join(Constants.MemorablePasswordSeparator, passwords);
    }

    public static string GeneratePassword(byte numbers, byte symbols, byte passwordLength, bool humanReadable = false)
    {
        // Ensure the numbers and symbols are valid
        ArgumentOutOfRangeException.ThrowIfNegative(numbers);
        ArgumentOutOfRangeException.ThrowIfNegative(symbols);

        // Ensure the password lenght is legit
        ArgumentOutOfRangeException.ThrowIfLessThan(passwordLength, Constants.MinimumPasswordLength);

        // Ensure the number and symbols are congruent with requested password length
        if (numbers + symbols > passwordLength)
            throw new ArgumentException("numbers and symbols length cannot be greater than requested password length");

        var numericAlphabet = Constants.NumericAlphabet;
        var characterAlphabet = Constants.CharacterAlphabet;
        if (humanReadable)
        {
            Log.Debug("Filtering out ambiguous characters form alphabets");
            numericAlphabet =
                new string(Constants.NumericAlphabet.Except(Constants.AmbiguousNumericAlphabet).ToArray());
            characterAlphabet =
                new string(Constants.CharacterAlphabet.Except(Constants.AmbiguousCharacterAlphabet).ToArray());
        }

        var numericString = new string(Enumerable.Range(0, numbers)
            .Select(_ => numericAlphabet.GetRandomCharacter())
            .ToArray());
        Log.Debug("Numeric String {String}", numericString);

        var symbolString = new string(Enumerable.Range(0, symbols)
            .Select(_ => Constants.SymbolAlphabet.GetRandomCharacter())
            .ToArray());
        Log.Debug("Symbol String: {String}", symbolString);

        var characterString = new string(Enumerable.Range(0, passwordLength - numbers - symbols)
            .Select(_ => characterAlphabet.GetRandomCharacter())
            .ToArray());
        Log.Debug("Character String: {String}", characterString);

        var rawPassword = $"{numericString}{characterString}{symbolString}";

        Log.Debug("Raw password: {String}", rawPassword);

        return new string(rawPassword.OrderBy(_ => Random.Shared.Next()).ToArray());
    }
}